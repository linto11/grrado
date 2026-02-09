using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.Core.DiagnosticRules.DeleteDiagnosticRule;

public class DeleteDiagnosticRuleValidator : AbstractValidator<DeleteDiagnosticRuleRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public DeleteDiagnosticRuleValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;

        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithErrorCode(ErrorCodes.DIAGNOSTIC_RULE_ID_INVALID)
            .WithMessage(GetMessage(ErrorCodes.DIAGNOSTIC_RULE_ID_INVALID, "Invalid diagnosticRule ID"));
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
