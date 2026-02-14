using GRRADO.Shared.Application.Common;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.AuditLogs.GetAuditLogById;

public record GetAuditLogByIdQuery(int Id) : IRequest<Result<AuditLogDto>>;
