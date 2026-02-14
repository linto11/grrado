using GRRADO.Shared.Application.Common;
using MediatR;

namespace LoggingService.Application.UseCases.AuditLogs.DeleteAuditLog;

public record DeleteAuditLogCommand(int Id) : IRequest<Result>;
