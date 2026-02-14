using GarageService.Application.DTOs;
using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Garages.GetGarageById;

public class GetGarageByIdQuery : IRequest<Result<GarageDto>>
{
    public int Id { get; set; }

    public GetGarageByIdQuery(int id) => Id = id;
}
