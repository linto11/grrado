using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.ImageDiagnostics.CreateImageDiagnostic;

public class CreateImageDiagnosticValidator : AbstractValidator<CreateImageDiagnosticRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public CreateImageDiagnosticValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
