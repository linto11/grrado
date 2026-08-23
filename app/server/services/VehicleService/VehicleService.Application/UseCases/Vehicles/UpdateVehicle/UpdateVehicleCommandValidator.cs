using FluentValidation;

namespace VehicleService.Application.UseCases.Vehicles.UpdateVehicle;

public class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
{
    public UpdateVehicleCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.UserId)
            .GreaterThan(0);

        RuleFor(x => x.Brand)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Model)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Year)
            .InclusiveBetween(1900, DateTime.Now.Year + 1);

        RuleFor(x => x.VehicleType)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.FuelType)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Color)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.MileageKm)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.LicensePlate)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.City)
            .NotEmpty()
            .MaximumLength(100);
    }
}
