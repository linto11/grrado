using FluentValidation;

namespace DiagnosticsService.Application.UseCases.DiagnosticRules.CreateDiagnosticRule;

public class CreateDiagnosticRuleCommandValidator : AbstractValidator<CreateDiagnosticRuleCommand>
{
    public CreateDiagnosticRuleCommandValidator()
    {
        RuleFor(x => x.Conditions)
            .NotEmpty()
            .MaximumLength(2000);

        RuleFor(x => x.LogicType)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Confidence)
            .InclusiveBetween(0, 1);

        RuleFor(x => x.Conclusion)
            .NotEmpty()
            .MaximumLength(1000);

        RuleFor(x => x.Description)
            .MaximumLength(2000);

        RuleFor(x => x.Priority)
            .GreaterThanOrEqualTo(0);
    }
}
