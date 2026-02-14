using AutoMapper;
using GRRADO.Shared.Application.Common;
using DiagnosticsService.Application.Abstractions;
using DiagnosticsService.Application.DTOs;
using DiagnosticsService.Domain.Entities;
using MediatR;

namespace DiagnosticsService.Application.UseCases.DiagnosticRules.UpdateDiagnosticRule;

public class UpdateDiagnosticRuleHandler : IRequestHandler<UpdateDiagnosticRuleCommand, Result<DiagnosticRuleDto>>
{
    private readonly IDiagnosticsUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateDiagnosticRuleHandler(IDiagnosticsUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<DiagnosticRuleDto>> Handle(UpdateDiagnosticRuleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.DiagnosticRules.GetByIdAsync(request.Id);
            if (entity == null)
                return Result<DiagnosticRuleDto>.Failure($"DiagnosticRule with id {request.Id} not found");

            entity.Conditions = request.Conditions;
            entity.LogicType = request.LogicType;
            entity.Confidence = request.Confidence;
            entity.Conclusion = request.Conclusion;
            entity.Description = request.Description;
            entity.Priority = request.Priority;
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.DiagnosticRules.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<DiagnosticRuleDto>.Success(_mapper.Map<DiagnosticRuleDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<DiagnosticRuleDto>.Failure($"Failed to update diagnostic rule: {ex.Message}");
        }
    }
}
