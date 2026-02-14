using System.Text;
using System.Text.Json;
using GRRADO.Shared.Abstractions.Messaging;
using GRRADO.Shared.Domain.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace GRRADO.Shared.Infrastructure.Messaging;

/// <summary>
/// RabbitMQ event publisher for integration events
/// </summary>
public class RabbitMqEventPublisher : IEventPublisher, IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly ILogger<RabbitMqEventPublisher> _logger;
    private const string ExchangeName = "grrado.events";

    public RabbitMqEventPublisher(IConfiguration configuration, ILogger<RabbitMqEventPublisher> logger)
    {
        _logger = logger;
        var factory = new ConnectionFactory
        {
            HostName = configuration["RabbitMQ:HostName"] ?? "localhost",
            Port = int.Parse(configuration["RabbitMQ:Port"] ?? "5672"),
            UserName = configuration["RabbitMQ:UserName"] ?? "guest",
            Password = configuration["RabbitMQ:Password"] ?? "guest"
        };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(ExchangeName, ExchangeType.Topic, durable: true);
    }

    public Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : IntegrationEvent
    {
        var routingKey = GetRoutingKey<T>();
        var message = JsonSerializer.Serialize(@event);
        var body = Encoding.UTF8.GetBytes(message);

        var properties = _channel.CreateBasicProperties();
        properties.Persistent = true;
        properties.MessageId = @event.EventId.ToString();
        properties.Timestamp = new AmqpTimestamp(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        properties.Type = @event.EventType;

        _channel.BasicPublish(ExchangeName, routingKey, properties, body);
        _logger.LogInformation("Published event {EventType} with ID {EventId} to routing key {RoutingKey}",
            @event.EventType, @event.EventId, routingKey);

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
