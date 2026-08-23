using FluentValidation;

namespace ServiceHistoryService.Application.UseCases.ServiceHistories.UpdateServiceHistory;

public class UpdateServiceHistoryCommandValidator : AbstractValidator<UpdateServiceHistoryCommand>
{
    public UpdateServiceHistoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.VehicleId)
            .GreaterThan(0);

        RuleFor(x => x.GarageId)
            .GreaterThan(0);

        RuleFor(x => x.ServiceId)
            .GreaterThan(0);

        RuleFor(x => x.ServiceDate)
            .NotEmpty();

        RuleFor(x => x.MileageKm)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.CostAed)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Outcome)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Notes)
            .MaximumLength(1000);

        RuleFor(x => x.TechnicianId)
            .GreaterThan(0)
            .When(x => x.TechnicianId.HasValue);
    }
}
