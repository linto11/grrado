using GRRADO.Shared.Domain;

namespace DiagnosticsService.Domain.Entities;

public class DiagnosticRule : IEntity
{
    public int Id { get; set; }
    public string Conditions { get; set; } = string.Empty;
    public string LogicType { get; set; } = string.Empty;
    public double Confidence { get; set; }
    public string Conclusion { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Priority { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
