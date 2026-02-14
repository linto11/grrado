using GRRADO.Shared.Application.Common;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.ErrorLogs.GetErrorLogById;

public record GetErrorLogByIdQuery(int Id) : IRequest<Result<ErrorLogDto>>;
