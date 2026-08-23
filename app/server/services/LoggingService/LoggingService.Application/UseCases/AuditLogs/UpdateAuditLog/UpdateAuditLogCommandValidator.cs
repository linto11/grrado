using FluentValidation;

namespace LoggingService.Application.UseCases.AuditLogs.UpdateAuditLog;

public class UpdateAuditLogCommandValidator : AbstractValidator<UpdateAuditLogCommand>
{
    public UpdateAuditLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.EntityType).NotEmpty().MaximumLength(100);
        RuleFor(x => x.EntityId).GreaterThan(0);
        RuleFor(x => x.Action).NotEmpty().MaximumLength(100);
        RuleFor(x => x.PerformedBy).MaximumLength(200).When(x => x.PerformedBy != null);
        RuleFor(x => x.IpAddress).MaximumLength(50).When(x => x.IpAddress != null);
        RuleFor(x => x.UserAgent).MaximumLength(500).When(x => x.UserAgent != null);
        RuleFor(x => x.UserId).GreaterThan(0).When(x => x.UserId.HasValue);
    }
}
