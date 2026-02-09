using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Core.Vehicles.DeleteVehicle;

public class DeleteVehicleRequest : IRequest<Result>
{
    public int Id { get; set; }

    public DeleteVehicleRequest(int id)
    {
        Id = id;
    }

    public DeleteVehicleRequest()
    {
    }
}
