using FluentValidation;

namespace LoggingService.Application.UseCases.ActivityLogs.CreateActivityLog;

public class CreateActivityLogCommandValidator : AbstractValidator<CreateActivityLogCommand>
{
    public CreateActivityLogCommandValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0).When(x => x.UserId.HasValue);
        RuleFor(x => x.ActivityType).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(2000);
        RuleFor(x => x.ResourceType).MaximumLength(100).When(x => x.ResourceType != null);
        RuleFor(x => x.ResourceId).GreaterThan(0).When(x => x.ResourceId.HasValue);
        RuleFor(x => x.IpAddress).MaximumLength(50).When(x => x.IpAddress != null);
    }
}
