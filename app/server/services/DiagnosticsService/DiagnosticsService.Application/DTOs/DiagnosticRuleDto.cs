namespace DiagnosticsService.Application.DTOs;

public class DiagnosticRuleDto
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
}
