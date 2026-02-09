using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.Core.DiagnosticRules.GetDiagnosticRuleById;

public class GetDiagnosticRuleByIdValidator : AbstractValidator<GetDiagnosticRuleByIdRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public GetDiagnosticRuleByIdValidator(IErrorMessageService errorMessageService)
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
