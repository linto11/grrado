using FluentValidation;

namespace DiagnosticsService.Application.UseCases.VehicleIssues.CreateVehicleIssue;

public class CreateVehicleIssueCommandValidator : AbstractValidator<CreateVehicleIssueCommand>
{
    public CreateVehicleIssueCommandValidator()
    {
        RuleFor(x => x.Symptom)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.AffectedSystem)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Severity)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(2000);

        RuleFor(x => x.PossibleCauses)
            .NotEmpty()
            .MaximumLength(2000);
    }
}
