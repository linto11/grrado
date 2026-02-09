using Application.Common.Models;
using Abstractions.DTOs.Vehicle;
using MediatR;

namespace Application.UseCases.Core.Vehicles.GetVehicleById;

public class GetVehicleByIdRequest : IRequest<Result<VehicleDto>>
{
    public int Id { get; set; }

    public GetVehicleByIdRequest(int id)
    {
        Id = id;
    }

    public GetVehicleByIdRequest()
    {
    }
}
