using Application.Common.Models;
using Abstractions.DTOs.Vehicle;
using Abstractions.Persistence;
using MediatR;

namespace Application.UseCases.Vehicles.GetAllVehicles;

public class GetAllVehiclesRequest : IRequest<Result<PaginatedResult<VehicleDto>>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
