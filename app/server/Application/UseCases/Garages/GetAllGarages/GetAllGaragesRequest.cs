using Application.Common.Models;
using Abstractions.DTOs.Garage;
using Abstractions.Persistence;
using MediatR;

namespace Application.UseCases.Garages.GetAllGarages;

public class GetAllGaragesRequest : IRequest<Result<PaginatedResult<GarageDto>>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
