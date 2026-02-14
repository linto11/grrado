using GRRADO.Shared.Application.Common;
using MediatR;

namespace LoggingService.Application.UseCases.ErrorMessages.DeleteErrorMessage;

public record DeleteErrorMessageCommand(int Id) : IRequest<Result>;
