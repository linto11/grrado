using Application.Common.Models;
using Abstractions.DTOs.ServiceHistory;
using Abstractions.Persistence;
using MediatR;

namespace Application.UseCases.Core.ServiceHistories.GetAllServiceHistories;

public class GetAllServiceHistoriesRequest : IRequest<Result<PaginatedResult<ServiceHistoryDto>>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
