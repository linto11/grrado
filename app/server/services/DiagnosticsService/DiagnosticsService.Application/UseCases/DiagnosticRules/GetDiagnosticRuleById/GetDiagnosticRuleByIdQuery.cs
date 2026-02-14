using GRRADO.Shared.Application.Common;
using MediatR;
using DiagnosticsService.Application.DTOs;

namespace DiagnosticsService.Application.UseCases.DiagnosticRules.GetDiagnosticRuleById;

public class GetDiagnosticRuleByIdQuery : IRequest<Result<DiagnosticRuleDto>>
{
    public int Id { get; set; }
    public GetDiagnosticRuleByIdQuery(int id) => Id = id;
}
