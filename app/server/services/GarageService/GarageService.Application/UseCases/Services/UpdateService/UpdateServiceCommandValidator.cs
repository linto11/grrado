using FluentValidation;

namespace GarageService.Application.UseCases.Services.UpdateService;

public class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCommand>
{
    public UpdateServiceCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.Request).NotNull();

        When(x => x.Request != null, () =>
        {
            RuleFor(x => x.Request.GarageId)
                .GreaterThan(0);

            RuleFor(x => x.Request.ServiceName)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Request.Category)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Request.AvgCostAed)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Request.SkillLevel)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Request.Description)
                .MaximumLength(1000);

            RuleFor(x => x.Request.EstimatedDurationMinutes)
                .GreaterThan(0);
        });
    }
}
