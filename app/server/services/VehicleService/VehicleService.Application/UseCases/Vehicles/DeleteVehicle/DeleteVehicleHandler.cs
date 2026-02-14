using GRRADO.Shared.Application.Common;
using VehicleService.Application.Abstractions;
using MediatR;

namespace VehicleService.Application.UseCases.Vehicles.DeleteVehicle;

public class DeleteVehicleHandler : IRequestHandler<DeleteVehicleCommand, Result>
{
    private readonly IVehicleUnitOfWork _unitOfWork;

    public DeleteVehicleHandler(IVehicleUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.Vehicles.GetByIdAsync(request.Id);
            if (entity == null)
                return Result.Failure($"Vehicle with id {request.Id} not found");

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
