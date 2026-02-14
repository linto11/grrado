using AutoMapper;
using GRRADO.Shared.Application.Common;
using DiagnosticsService.Application.Abstractions;
using DiagnosticsService.Application.DTOs;
using DiagnosticsService.Domain.Entities;
using MediatR;

namespace DiagnosticsService.Application.UseCases.DiagnosticRules.CreateDiagnosticRule;

public class CreateDiagnosticRuleHandler : IRequestHandler<CreateDiagnosticRuleCommand, Result<DiagnosticRuleDto>>
{
    private readonly IDiagnosticsUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateDiagnosticRuleHandler(IDiagnosticsUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<DiagnosticRuleDto>> Handle(CreateDiagnosticRuleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<DiagnosticRule>(request);
            await _unitOfWork.DiagnosticRules.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<DiagnosticRuleDto>.Success(_mapper.Map<DiagnosticRuleDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<DiagnosticRuleDto>.Failure($"Failed to create diagnostic rule: {ex.Message}");
        }
    }
}
