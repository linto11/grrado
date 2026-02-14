using GRRADO.Shared.Application.Common;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.AuditLogs.UpdateAuditLog;

public class UpdateAuditLogCommand : IRequest<Result<AuditLogDto>>
{
    public int Id { get; set; }
    public string EntityType { get; set; } = string.Empty;
    public int EntityId { get; set; }
    public string Action { get; set; } = string.Empty;
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public string? ChangedFields { get; set; }
    public int? UserId { get; set; }
    public string? PerformedBy { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
    public string? Metadata { get; set; }
}
