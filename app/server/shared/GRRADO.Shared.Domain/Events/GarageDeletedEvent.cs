namespace GRRADO.Shared.Domain.Events;

public class GarageDeletedEvent : IntegrationEvent
{
    public int GarageId { get; set; }
    public string DeletedBy { get; set; } = string.Empty;
}
