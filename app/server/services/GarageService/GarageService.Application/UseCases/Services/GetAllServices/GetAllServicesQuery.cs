using GarageService.Application.DTOs;
using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Services.GetAllServices;

public class GetAllServicesQuery : IRequest<Result<List<ServiceDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
