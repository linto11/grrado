using GRRADO.Shared.Application.Common;
using DiagnosticsService.Application.Abstractions;
using MediatR;

namespace DiagnosticsService.Application.UseCases.DiagnosticRules.DeleteDiagnosticRule;

public class DeleteDiagnosticRuleHandler : IRequestHandler<DeleteDiagnosticRuleCommand, Result>
{
    private readonly IDiagnosticsUnitOfWork _unitOfWork;

    public DeleteDiagnosticRuleHandler(IDiagnosticsUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteDiagnosticRuleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.DiagnosticRules.GetByIdAsync(request.Id);
            if (entity == null)
                return Result.Failure($"DiagnosticRule with id {request.Id} not found");

            await _unitOfWork.DiagnosticRules.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete diagnostic rule: {ex.Message}");
        }
    }
}
