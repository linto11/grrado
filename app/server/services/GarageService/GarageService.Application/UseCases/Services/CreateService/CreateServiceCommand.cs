using GarageService.Application.DTOs;
using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Services.CreateService;

public class CreateServiceCommand : IRequest<Result<ServiceDto>>
{
    public CreateServiceRequest Request { get; set; } = null!;
}
