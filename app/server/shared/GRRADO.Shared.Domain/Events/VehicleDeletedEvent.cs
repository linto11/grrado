namespace GRRADO.Shared.Domain.Events;

public class VehicleDeletedEvent : IntegrationEvent
{
    public int VehicleId { get; set; }
    public int UserId { get; set; }
    public string DeletedBy { get; set; } = string.Empty;
}
