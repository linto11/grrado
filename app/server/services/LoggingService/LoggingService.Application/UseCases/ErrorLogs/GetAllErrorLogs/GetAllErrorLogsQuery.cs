using GRRADO.Shared.Application.Common;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.ErrorLogs.GetAllErrorLogs;

public class GetAllErrorLogsQuery : IRequest<Result<List<ErrorLogDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
