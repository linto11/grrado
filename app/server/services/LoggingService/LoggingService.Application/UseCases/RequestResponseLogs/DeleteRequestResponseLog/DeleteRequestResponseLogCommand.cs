using GRRADO.Shared.Application.Common;
using MediatR;

namespace LoggingService.Application.UseCases.RequestResponseLogs.DeleteRequestResponseLog;

public record DeleteRequestResponseLogCommand(int Id) : IRequest<Result>;
