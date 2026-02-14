using GRRADO.Shared.Application.Common;
using MediatR;

namespace LoggingService.Application.UseCases.ErrorLogs.DeleteErrorLog;

public record DeleteErrorLogCommand(int Id) : IRequest<Result>;
