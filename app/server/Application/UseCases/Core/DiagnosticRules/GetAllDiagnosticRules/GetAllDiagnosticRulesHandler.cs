using Abstractions.DTOs.DiagnosticRule;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Core.DiagnosticRules.GetAllDiagnosticRules;

public class GetAllDiagnosticRulesHandler : IRequestHandler<GetAllDiagnosticRulesRequest, Result<PaginatedResult<DiagnosticRuleDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllDiagnosticRulesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<PaginatedResult<DiagnosticRuleDto>>> Handle(GetAllDiagnosticRulesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var pagedResult = await _unitOfWork.DiagnosticRules.GetPagedAsync(request.PageNumber, request.PageSize);
            var dtos = _mapper.Map<List<DiagnosticRuleDto>>(pagedResult.Items);
            var paginatedResult = new PaginatedResult<DiagnosticRuleDto>
            {
                Items = dtos,
                TotalCount = pagedResult.TotalCount,
                Skip = pagedResult.Skip,
                Take = pagedResult.Take
            };
            return Result<PaginatedResult<DiagnosticRuleDto>>.Success(paginatedResult);
        }
        catch (Exception ex)
        {
            return Result<PaginatedResult<DiagnosticRuleDto>>.Failure($"Failed to retrieve diagnosticRule list: {ex.Message}");
        }
    }
}
