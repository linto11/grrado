using GRRADO.Shared.Application.Common;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.ActivityLogs.UpdateActivityLog;

public class UpdateActivityLogCommand : IRequest<Result<ActivityLogDto>>
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string ActivityType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ResourceType { get; set; }
    public int? ResourceId { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
    public string? Metadata { get; set; }
}
