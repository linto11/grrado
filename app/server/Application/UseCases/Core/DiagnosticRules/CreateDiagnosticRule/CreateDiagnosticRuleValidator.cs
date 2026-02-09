using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.Core.DiagnosticRules.CreateDiagnosticRule;

public class CreateDiagnosticRuleValidator : AbstractValidator<CreateDiagnosticRuleRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public CreateDiagnosticRuleValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
