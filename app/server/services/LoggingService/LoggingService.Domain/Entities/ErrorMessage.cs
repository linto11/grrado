using GRRADO.Shared.Domain;

namespace LoggingService.Domain.Entities;

public class ErrorMessage : IEntity
{
    public int Id { get; set; }
    public Guid Code { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string? UseCase { get; set; }
    public string? LocaleCode { get; set; } = "en-US";

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
