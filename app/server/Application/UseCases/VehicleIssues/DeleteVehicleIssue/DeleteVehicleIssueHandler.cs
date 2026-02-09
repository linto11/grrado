using Abstractions.Persistence;
using Application.Common.Models;
using MediatR;

namespace Application.UseCases.VehicleIssues.DeleteVehicleIssue;

public class DeleteVehicleIssueHandler : IRequestHandler<DeleteVehicleIssueRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVehicleIssueHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVehicleIssueRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.VehicleIssues.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result.Failure($"VehicleIssue with ID {request.Id} not found");
            }
            await _unitOfWork.VehicleIssues.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete vehicleIssue: {ex.Message}");
        }
    }
}
