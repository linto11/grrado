using GRRADO.Shared.Domain.Events;

namespace GRRADO.Shared.Abstractions.Messaging;

/// <summary>
/// Publishes integration events to RabbitMQ
/// </summary>
public interface IEventPublisher
{
    Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : IntegrationEvent;
}
