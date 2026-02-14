using GRRADO.Shared.Application.Common;
using LoggingService.Application.DTOs;
using MediatR;

namespace LoggingService.Application.UseCases.ErrorMessages.UpdateErrorMessage;

public class UpdateErrorMessageCommand : IRequest<Result<ErrorMessageDto>>
{
    public int Id { get; set; }
    public Guid Code { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string? UseCase { get; set; }
    public string? LocaleCode { get; set; }
}
