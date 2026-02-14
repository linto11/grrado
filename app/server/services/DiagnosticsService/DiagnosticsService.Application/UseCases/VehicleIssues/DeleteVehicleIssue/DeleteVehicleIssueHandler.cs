using GRRADO.Shared.Application.Common;
using DiagnosticsService.Application.Abstractions;
using MediatR;

namespace DiagnosticsService.Application.UseCases.VehicleIssues.DeleteVehicleIssue;

public class DeleteVehicleIssueHandler : IRequestHandler<DeleteVehicleIssueCommand, Result>
{
    private readonly IDiagnosticsUnitOfWork _unitOfWork;

    public DeleteVehicleIssueHandler(IDiagnosticsUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVehicleIssueCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.VehicleIssues.GetByIdAsync(request.Id);
            if (entity == null)
                return Result.Failure($"VehicleIssue with id {request.Id} not found");

            await _unitOfWork.VehicleIssues.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete vehicle issue: {ex.Message}");
        }
    }
}
