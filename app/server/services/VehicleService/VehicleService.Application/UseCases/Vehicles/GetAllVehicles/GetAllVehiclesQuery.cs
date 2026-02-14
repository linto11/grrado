using GRRADO.Shared.Application.Common;
using MediatR;
using VehicleService.Application.DTOs;

namespace VehicleService.Application.UseCases.Vehicles.GetAllVehicles;

public class GetAllVehiclesQuery : IRequest<Result<List<VehicleDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
