using Abstractions.DTOs.DiagnosticRule;
using Abstractions.Persistence;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Core;

public interface IDiagnosticRuleService : IBaseService<DiagnosticRule, DiagnosticRuleDto, CreateDiagnosticRuleRequest, UpdateDiagnosticRuleRequest>
{
}

public class DiagnosticRuleService : BaseService<DiagnosticRule, DiagnosticRuleDto, CreateDiagnosticRuleRequest, UpdateDiagnosticRuleRequest>, IDiagnosticRuleService
{
    public DiagnosticRuleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    protected override IRepository<DiagnosticRule> GetRepository() => _unitOfWork.DiagnosticRules;
}
