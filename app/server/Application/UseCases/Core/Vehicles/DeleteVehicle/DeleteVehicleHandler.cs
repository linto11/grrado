using Abstractions.Persistence;
using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Core.Vehicles.DeleteVehicle;

public class DeleteVehicleHandler : IRequestHandler<DeleteVehicleRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVehicleHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVehicleRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.Vehicles.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result.Failure($"Vehicle with ID {request.Id} not found");
            }
            await _unitOfWork.Vehicles.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete vehicle: {ex.Message}");
        }
    }
}
