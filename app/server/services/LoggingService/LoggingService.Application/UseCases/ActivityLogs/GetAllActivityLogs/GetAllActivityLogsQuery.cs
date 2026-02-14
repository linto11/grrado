using GRRADO.Shared.Application.Common;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.ActivityLogs.GetAllActivityLogs;

public class GetAllActivityLogsQuery : IRequest<Result<List<ActivityLogDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
