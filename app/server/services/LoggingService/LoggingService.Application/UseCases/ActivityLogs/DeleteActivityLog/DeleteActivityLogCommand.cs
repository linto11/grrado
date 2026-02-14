using GRRADO.Shared.Application.Common;
using MediatR;

namespace LoggingService.Application.UseCases.ActivityLogs.DeleteActivityLog;

public record DeleteActivityLogCommand(int Id) : IRequest<Result>;
