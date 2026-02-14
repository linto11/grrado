using GRRADO.Shared.Application.Common;
using MediatR;
using DiagnosticsService.Application.DTOs;

namespace DiagnosticsService.Application.UseCases.DiagnosticRules.CreateDiagnosticRule;

public class CreateDiagnosticRuleCommand : IRequest<Result<DiagnosticRuleDto>>
{
    public string Conditions { get; set; } = string.Empty;
    public string LogicType { get; set; } = string.Empty;
    public double Confidence { get; set; }
    public string Conclusion { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Priority { get; set; }
}
