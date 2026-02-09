using Application.Common.Models;
using Abstractions.DTOs.Garage;
using MediatR;

namespace Application.UseCases.Garages.GetGarageById;

public class GetGarageByIdRequest : IRequest<Result<GarageDto>>
{
    public int Id { get; set; }

    public GetGarageByIdRequest(int id)
    {
        Id = id;
    }

    public GetGarageByIdRequest()
    {
    }
}
