using GRRADO.Shared.Application.Common;
using MediatR;
using DiagnosticsService.Application.DTOs;

namespace DiagnosticsService.Application.UseCases.DiagnosticRules.GetAllDiagnosticRules;

public class GetAllDiagnosticRulesQuery : IRequest<Result<List<DiagnosticRuleDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
