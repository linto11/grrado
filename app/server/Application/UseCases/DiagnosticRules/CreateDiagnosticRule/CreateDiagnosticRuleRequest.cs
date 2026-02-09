using Application.Common.Models;
using Abstractions.DTOs.DiagnosticRule;
using MediatR;

namespace Application.UseCases.DiagnosticRules.CreateDiagnosticRule;

public class CreateDiagnosticRuleRequest : IRequest<Result<DiagnosticRuleDto>>
{
    public string VehicleType { get; set; } = string.Empty;
    public string IssueType { get; set; } = string.Empty;
    public int MileageThreshold { get; set; }
    public string RecommendedAction { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
}
