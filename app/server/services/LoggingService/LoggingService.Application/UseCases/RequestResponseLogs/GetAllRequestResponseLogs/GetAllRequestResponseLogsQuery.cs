using GRRADO.Shared.Application.Common;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.RequestResponseLogs.GetAllRequestResponseLogs;

public class GetAllRequestResponseLogsQuery : IRequest<Result<List<RequestResponseLogDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
