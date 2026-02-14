namespace GRRADO.Shared.Domain.Events;

public class UserDeletedEvent : IntegrationEvent
{
    public int UserId { get; set; }
    public string DeletedBy { get; set; } = string.Empty;
}
