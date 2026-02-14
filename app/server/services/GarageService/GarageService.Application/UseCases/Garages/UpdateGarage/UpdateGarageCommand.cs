using GarageService.Application.DTOs;
using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Garages.UpdateGarage;

public class UpdateGarageCommand : IRequest<Result<GarageDto>>
{
    public int Id { get; set; }
    public UpdateGarageRequest Request { get; set; } = null!;
}
