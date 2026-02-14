using GRRADO.Shared.Application.Common;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.ErrorMessages.CreateErrorMessage;

public class CreateErrorMessageCommand : IRequest<Result<ErrorMessageDto>>
{
    public Guid Code { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string? UseCase { get; set; }
    public string? LocaleCode { get; set; } = "en-US";
}
