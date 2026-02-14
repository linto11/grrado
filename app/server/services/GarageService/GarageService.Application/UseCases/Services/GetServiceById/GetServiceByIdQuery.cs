using GarageService.Application.DTOs;
using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Services.GetServiceById;

public class GetServiceByIdQuery : IRequest<Result<ServiceDto>>
{
    public int Id { get; set; }

    public GetServiceByIdQuery(int id) => Id = id;
}
