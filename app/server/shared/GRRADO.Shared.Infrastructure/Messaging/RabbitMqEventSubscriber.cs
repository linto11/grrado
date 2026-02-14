using System.Text;
using System.Text.Json;
using GRRADO.Shared.Abstractions.Messaging;
using GRRADO.Shared.Domain.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace GRRADO.Shared.Infrastructure.Messaging;

/// <summary>
/// RabbitMQ event subscriber for integration events
/// </summary>
public class RabbitMqEventSubscriber : IEventSubscriber, IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly ILogger<RabbitMqEventSubscriber> _logger;
    private readonly string _queueName;
    private const string ExchangeName = "grrado.events";
    private readonly Dictionary<string, Func<string, Task>> _handlers = new();

    public RabbitMqEventSubscriber(
        IConfiguration configuration,
        ILogger<RabbitMqEventSubscriber> logger,
        string serviceName)
    {
        _logger = logger;
        _queueName = $"grrado.{serviceName}.queue";

        var factory = new ConnectionFactory
        {
            HostName = configuration["RabbitMQ:HostName"] ?? "localhost",
            Port = int.Parse(configuration["RabbitMQ:Port"] ?? "5672"),
            UserName = configuration["RabbitMQ:UserName"] ?? "guest",
            Password = configuration["RabbitMQ:Password"] ?? "guest",
            DispatchConsumersAsync = true
        };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(ExchangeName, ExchangeType.Topic, durable: true);
        _channel.QueueDeclare(_queueName, durable: true, exclusive: false, autoDelete: false);
    }

    public void Subscribe<T>(Func<T, Task> handler) where T : IntegrationEvent
    {
        var routingKey = GetRoutingKey<T>();
        _channel.QueueBind(_queueName, ExchangeName, routingKey);

        _handlers[typeof(T).Name] = async (message) =>
        {
            var @event = JsonSerializer.Deserialize<T>(message);
            if (@event != null)
                await handler(@event);
        };

        _logger.LogInformation("Subscribed to {EventType} with routing key {RoutingKey}", typeof(T).Name, routingKey);
    }

    public Task StartAsync(CancellationToken cancellationToken = default)
    {
        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.Received += async (_, ea) =>
        {
            try
            {
                var body = Encoding.UTF8.GetString(ea.Body.ToArray());
                var eventType = ea.BasicProperties.Type;

                if (_handlers.TryGetValue(eventType, out var handler))
                {
                    await handler(body);
                    _channel.BasicAck(ea.DeliveryTag, false);
                    _logger.LogInformation("Processed event {EventType}", eventType);
                }
                else
                {
                    _logger.LogWarning("No handler for event type {EventType}", eventType);
                    _channel.BasicNack(ea.DeliveryTag, false, true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing message");
                _channel.BasicNack(ea.DeliveryTag, false, true);
            }
        };

        _channel.BasicConsume(_queueName, autoAck: false, consumer);
        _logger.LogInformation("Started consuming from queue {QueueName}", _queueName);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken = default)
    {
        _channel?.Close();
        _connection?.Close();
        return Task.CompletedTask;
    }

    private static string GetRoutingKey<T>() where T : IntegrationEvent
    {
        var typeName = typeof(T).Name;
        return typeName
            .Replace("Event", "")
            .Replace("Deleted", ".deleted")
            .Replace("Created", ".created")
            .Replace("Updated", ".updated")
            .ToLowerInvariant()
            .TrimStart('.');
    }

    public void Dispose()
    {
        _channel?.Dispose();
        _connection?.Dispose();
    }
}
