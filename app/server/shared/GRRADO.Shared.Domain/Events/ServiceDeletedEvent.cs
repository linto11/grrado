namespace GRRADO.Shared.Domain.Events;

public class ServiceDeletedEvent : IntegrationEvent
{
    public int ServiceId { get; set; }
    public int GarageId { get; set; }
    public string DeletedBy { get; set; } = string.Empty;
}
