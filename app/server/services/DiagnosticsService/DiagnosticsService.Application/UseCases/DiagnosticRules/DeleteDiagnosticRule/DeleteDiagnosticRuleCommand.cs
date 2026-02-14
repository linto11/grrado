using GRRADO.Shared.Application.Common;
using MediatR;

namespace DiagnosticsService.Application.UseCases.DiagnosticRules.DeleteDiagnosticRule;

public class DeleteDiagnosticRuleCommand : IRequest<Result>
{
    public int Id { get; set; }
    public DeleteDiagnosticRuleCommand(int id) => Id = id;
}
