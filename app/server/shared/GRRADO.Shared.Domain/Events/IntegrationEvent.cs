namespace GRRADO.Shared.Domain.Events;

/// <summary>
/// Base class for integration events published across microservices via RabbitMQ
/// </summary>
public abstract class IntegrationEvent
{
    public Guid EventId { get; } = Guid.NewGuid();
    public DateTime OccurredAt { get; } = DateTime.UtcNow;
    public string EventType => GetType().Name;
}
