using FluentValidation;

namespace DiagnosticsService.Application.UseCases.ImageDiagnostics.UpdateImageDiagnostic;

public class UpdateImageDiagnosticCommandValidator : AbstractValidator<UpdateImageDiagnosticCommand>
{
    public UpdateImageDiagnosticCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.VisualFeature)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.Confidence)
            .InclusiveBetween(0, 1);

        RuleFor(x => x.LikelyIssue)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.Urgency)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.FilePath)
            .NotEmpty()
            .MaximumLength(1000);

        RuleFor(x => x.ImageType)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Description)
            .MaximumLength(2000);
    }
}
