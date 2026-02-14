using GRRADO.Shared.Application.Common;
using MediatR;
using VehicleService.Application.DTOs;

namespace VehicleService.Application.UseCases.Vehicles.GetVehicleById;

public class GetVehicleByIdQuery : IRequest<Result<VehicleDto>>
{
    public int Id { get; set; }
    public GetVehicleByIdQuery(int id) => Id = id;
}
