using Abstractions.DTOs.DiagnosticRule;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Core.DiagnosticRules.CreateDiagnosticRule;

public class CreateDiagnosticRuleHandler : IRequestHandler<CreateDiagnosticRuleRequest, Result<DiagnosticRuleDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateDiagnosticRuleHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<DiagnosticRuleDto>> Handle(CreateDiagnosticRuleRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Domain.Entities.DiagnosticRule>(request);
            await _unitOfWork.DiagnosticRules.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<DiagnosticRuleDto>(entity);
            return Result<DiagnosticRuleDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<DiagnosticRuleDto>.Failure($"Failed to create diagnosticRule: {ex.Message}");
        }
    }
}
