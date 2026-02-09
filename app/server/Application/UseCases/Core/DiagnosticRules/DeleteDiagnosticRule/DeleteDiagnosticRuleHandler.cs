using Abstractions.Persistence;
using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Core.DiagnosticRules.DeleteDiagnosticRule;

public class DeleteDiagnosticRuleHandler : IRequestHandler<DeleteDiagnosticRuleRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDiagnosticRuleHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteDiagnosticRuleRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.DiagnosticRules.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result.Failure($"DiagnosticRule with ID {request.Id} not found");
            }
            await _unitOfWork.DiagnosticRules.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete diagnosticRule: {ex.Message}");
        }
    }
}
