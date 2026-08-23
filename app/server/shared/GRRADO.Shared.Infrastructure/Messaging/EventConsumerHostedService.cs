using GRRADO.Shared.Abstractions.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GRRADO.Shared.Infrastructure.Messaging;

public abstract class EventConsumerHostedService : BackgroundService
{
    protected readonly IEventSubscriber _subscriber;
    protected readonly IServiceProvider _serviceProvider;
    protected readonly ILogger _logger;

    protected EventConsumerHostedService(
        IConfiguration configuration,
        IServiceProvider serviceProvider,
        ILogger logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _subscriber = new RabbitMqEventSubscriber(
            configuration,
            LoggerFactory.Create(b => b.AddConsole()).CreateLogger<RabbitMqEventSubscriber>(),
            ServiceName);
    }

    protected abstract string ServiceName { get; }
    protected abstract void ConfigureSubscriptions();

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            ConfigureSubscriptions();
            await _subscriber.StartAsync(stoppingToken);
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("{ServiceName} event consumer stopping", ServiceName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{ServiceName} event consumer encountered an error", ServiceName);
        }
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await _subscriber.StopAsync(cancellationToken);
        await base.StopAsync(cancellationToken);
    }
}
