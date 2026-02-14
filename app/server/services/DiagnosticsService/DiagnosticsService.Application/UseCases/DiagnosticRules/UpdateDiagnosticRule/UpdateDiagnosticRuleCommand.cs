using GRRADO.Shared.Application.Common;
using MediatR;
using DiagnosticsService.Application.DTOs;

namespace DiagnosticsService.Application.UseCases.DiagnosticRules.UpdateDiagnosticRule;

public class UpdateDiagnosticRuleCommand : IRequest<Result<DiagnosticRuleDto>>
{
    public int Id { get; set; }
    public string Conditions { get; set; } = string.Empty;
    public string LogicType { get; set; } = string.Empty;
    public double Confidence { get; set; }
    public string Conclusion { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Priority { get; set; }
}
