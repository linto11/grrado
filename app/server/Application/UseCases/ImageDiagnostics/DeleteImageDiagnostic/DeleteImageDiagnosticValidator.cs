using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.ImageDiagnostics.DeleteImageDiagnostic;

public class DeleteImageDiagnosticValidator : AbstractValidator<DeleteImageDiagnosticRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public DeleteImageDiagnosticValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;

        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithErrorCode(ErrorCodes.IMAGE_DIAGNOSTIC_ID_INVALID)
            .WithMessage(GetMessage(ErrorCodes.IMAGE_DIAGNOSTIC_ID_INVALID, "Invalid imageDiagnostic ID"));
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
