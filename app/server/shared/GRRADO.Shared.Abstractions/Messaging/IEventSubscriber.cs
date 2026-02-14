using GRRADO.Shared.Domain.Events;

namespace GRRADO.Shared.Abstractions.Messaging;

/// <summary>
/// Subscribes to integration events from RabbitMQ
/// </summary>
public interface IEventSubscriber
{
    void Subscribe<T>(Func<T, Task> handler) where T : IntegrationEvent;
    Task StartAsync(CancellationToken cancellationToken = default);
    Task StopAsync(CancellationToken cancellationToken = default);
}
