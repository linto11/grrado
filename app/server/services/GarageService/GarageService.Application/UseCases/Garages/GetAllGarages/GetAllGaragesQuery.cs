using GarageService.Application.DTOs;
using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Garages.GetAllGarages;

public class GetAllGaragesQuery : IRequest<Result<List<GarageDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
