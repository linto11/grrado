using FluentValidation;

namespace GarageService.Application.UseCases.Garages.CreateGarage;

public class CreateGarageCommandValidator : AbstractValidator<CreateGarageCommand>
{
    public CreateGarageCommandValidator()
    {
        RuleFor(x => x.Request).NotNull();

        When(x => x.Request != null, () =>
        {
            RuleFor(x => x.Request.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Request.City)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Request.Address)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Request.PhoneNumber)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.Request.GarageType)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Request.Rating)
                .InclusiveBetween(0, 5);

            RuleFor(x => x.Request.OperatingHours)
                .NotEmpty()
                .MaximumLength(200);
        });
    }
}
