using GRRADO.Shared.Application.Common;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.RequestResponseLogs.GetRequestResponseLogById;

public record GetRequestResponseLogByIdQuery(int Id) : IRequest<Result<RequestResponseLogDto>>;
