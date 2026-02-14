using GarageService.Application.DTOs;
using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Garages.CreateGarage;

public class CreateGarageCommand : IRequest<Result<GarageDto>>
{
    public CreateGarageRequest Request { get; set; } = null!;
}
