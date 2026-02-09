using Application.Common.Models;
using Abstractions.DTOs.DiagnosticRule;
using Abstractions.Persistence;
using MediatR;

namespace Application.UseCases.DiagnosticRules.GetAllDiagnosticRules;

public class GetAllDiagnosticRulesRequest : IRequest<Result<PaginatedResult<DiagnosticRuleDto>>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
