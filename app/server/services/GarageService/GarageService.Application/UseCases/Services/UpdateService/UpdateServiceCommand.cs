using GarageService.Application.DTOs;
using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Services.UpdateService;

public class UpdateServiceCommand : IRequest<Result<ServiceDto>>
{
    public int Id { get; set; }
    public UpdateServiceRequest Request { get; set; } = null!;
}
