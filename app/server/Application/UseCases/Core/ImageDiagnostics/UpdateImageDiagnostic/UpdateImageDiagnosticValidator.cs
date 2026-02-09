using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.Core.ImageDiagnostics.UpdateImageDiagnostic;

public class UpdateImageDiagnosticValidator : AbstractValidator<UpdateImageDiagnosticRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public UpdateImageDiagnosticValidator(IErrorMessageService errorMessageService)
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
