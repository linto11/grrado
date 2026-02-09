using Abstractions.DTOs.DiagnosticRule;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.DiagnosticRules.GetDiagnosticRuleById;

public class GetDiagnosticRuleByIdHandler : IRequestHandler<GetDiagnosticRuleByIdRequest, Result<DiagnosticRuleDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetDiagnosticRuleByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<DiagnosticRuleDto>> Handle(GetDiagnosticRuleByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.DiagnosticRules.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<DiagnosticRuleDto>.Failure($"DiagnosticRule with ID {request.Id} not found");
            }
            var dto = _mapper.Map<DiagnosticRuleDto>(entity);
            return Result<DiagnosticRuleDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<DiagnosticRuleDto>.Failure($"Failed to retrieve diagnosticRule: {ex.Message}");
        }
    }
}
