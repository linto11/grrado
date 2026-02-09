using Application.Common.Models;
using Abstractions.DTOs.DiagnosticRule;
using MediatR;

namespace Application.UseCases.DiagnosticRules.UpdateDiagnosticRule;

public class UpdateDiagnosticRuleRequest : IRequest<Result<DiagnosticRuleDto>>
{
    public int Id { get; set; }
    public string VehicleType { get; set; } = string.Empty;
    public string IssueType { get; set; } = string.Empty;
    public int MileageThreshold { get; set; }
    public string RecommendedAction { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
}
