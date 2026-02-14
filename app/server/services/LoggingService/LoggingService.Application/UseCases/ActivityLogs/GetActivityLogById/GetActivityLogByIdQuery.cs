using GRRADO.Shared.Application.Common;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.ActivityLogs.GetActivityLogById;

public record GetActivityLogByIdQuery(int Id) : IRequest<Result<ActivityLogDto>>;
