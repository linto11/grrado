using GRRADO.Shared.Application.Common;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.AuditLogs.GetAllAuditLogs;

public class GetAllAuditLogsQuery : IRequest<Result<List<AuditLogDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
