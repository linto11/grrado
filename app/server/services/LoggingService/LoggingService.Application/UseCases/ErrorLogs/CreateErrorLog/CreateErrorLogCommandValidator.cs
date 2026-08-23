using FluentValidation;

namespace LoggingService.Application.UseCases.ErrorLogs.CreateErrorLog;

public class CreateErrorLogCommandValidator : AbstractValidator<CreateErrorLogCommand>
{
    public CreateErrorLogCommandValidator()
    {
        RuleFor(x => x.ErrorCode).NotEmpty().MaximumLength(100);
        RuleFor(x => x.ErrorMessage).NotEmpty().MaximumLength(2000);
        RuleFor(x => x.StackTrace).NotEmpty();
        RuleFor(x => x.Source).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Severity).NotEmpty().MaximumLength(50);
        RuleFor(x => x.UserId).GreaterThan(0).When(x => x.UserId.HasValue);
        RuleFor(x => x.IpAddress).MaximumLength(50).When(x => x.IpAddress != null);
    }
}
