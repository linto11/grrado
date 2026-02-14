using AutoMapper;
using GRRADO.Shared.Application.Common;
using DiagnosticsService.Application.Abstractions;
using DiagnosticsService.Application.DTOs;
using MediatR;

namespace DiagnosticsService.Application.UseCases.DiagnosticRules.GetDiagnosticRuleById;

public class GetDiagnosticRuleByIdHandler : IRequestHandler<GetDiagnosticRuleByIdQuery, Result<DiagnosticRuleDto>>
{
    private readonly IDiagnosticsUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetDiagnosticRuleByIdHandler(IDiagnosticsUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<DiagnosticRuleDto>> Handle(GetDiagnosticRuleByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.DiagnosticRules.GetByIdAsync(request.Id);
            if (entity == null)
                return Result<DiagnosticRuleDto>.Failure($"DiagnosticRule with id {request.Id} not found");
            return Result<DiagnosticRuleDto>.Success(_mapper.Map<DiagnosticRuleDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<DiagnosticRuleDto>.Failure($"Failed to get diagnostic rule: {ex.Message}");
        }
    }
}
