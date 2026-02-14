using GRRADO.Shared.Application.Common;
using MediatR;
using ServiceHistoryService.Application.DTOs;

namespace ServiceHistoryService.Application.UseCases.ServiceHistories.GetAllServiceHistories;

public class GetAllServiceHistoriesQuery : IRequest<Result<List<ServiceHistoryDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
