using AutoMapper;
using GRRADO.Shared.Application.Common;
using DiagnosticsService.Application.Abstractions;
using DiagnosticsService.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiagnosticsService.Application.UseCases.DiagnosticRules.GetAllDiagnosticRules;

public class GetAllDiagnosticRulesHandler : IRequestHandler<GetAllDiagnosticRulesQuery, Result<List<DiagnosticRuleDto>>>
{
    private readonly IDiagnosticsUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllDiagnosticRulesHandler(IDiagnosticsUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<DiagnosticRuleDto>>> Handle(GetAllDiagnosticRulesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await _unitOfWork.DiagnosticRules.GetAll()
                .Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
            var dtos = _mapper.Map<List<DiagnosticRuleDto>>(entities);
            return Result<List<DiagnosticRuleDto>>.Success(dtos);
        }
        catch (Exception ex)
        {
            return Result<List<DiagnosticRuleDto>>.Failure($"Failed to get diagnostic rules: {ex.Message}");
        }
    }
}
