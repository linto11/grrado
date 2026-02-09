using Application.Common.Models;
using Abstractions.DTOs.DiagnosticRule;
using MediatR;

namespace Application.UseCases.Core.DiagnosticRules.GetDiagnosticRuleById;

public class GetDiagnosticRuleByIdRequest : IRequest<Result<DiagnosticRuleDto>>
{
    public int Id { get; set; }

    public GetDiagnosticRuleByIdRequest(int id)
    {
        Id = id;
    }

    public GetDiagnosticRuleByIdRequest()
    {
    }
}
