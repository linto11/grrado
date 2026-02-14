using GRRADO.Shared.Application.Common;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.ErrorMessages.GetErrorMessageById;

public record GetErrorMessageByIdQuery(int Id) : IRequest<Result<ErrorMessageDto>>;
