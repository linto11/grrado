using GRRADO.Shared.Application.Common;
using MediatR;

namespace VehicleService.Application.UseCases.Vehicles.DeleteVehicle;

public class DeleteVehicleCommand : IRequest<Result>
{
    public int Id { get; set; }
    public DeleteVehicleCommand(int id) => Id = id;
}
