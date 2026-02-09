using Application.Common.Models;
using Abstractions.DTOs.Service;
using Abstractions.Persistence;
using MediatR;

namespace Application.UseCases.Core.Services.GetAllServices;

public class GetAllServicesRequest : IRequest<Result<PaginatedResult<ServiceDto>>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
