using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Core.DiagnosticRules.DeleteDiagnosticRule;

public class DeleteDiagnosticRuleRequest : IRequest<Result>
{
    public int Id { get; set; }

    public DeleteDiagnosticRuleRequest(int id)
    {
        Id = id;
    }

    public DeleteDiagnosticRuleRequest()
    {
    }
}
