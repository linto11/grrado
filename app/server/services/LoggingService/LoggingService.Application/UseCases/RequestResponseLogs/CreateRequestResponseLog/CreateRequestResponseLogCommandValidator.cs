using FluentValidation;

namespace LoggingService.Application.UseCases.RequestResponseLogs.CreateRequestResponseLog;

public class CreateRequestResponseLogCommandValidator : AbstractValidator<CreateRequestResponseLogCommand>
{
    public CreateRequestResponseLogCommandValidator()
    {
        RuleFor(x => x.RequestId).NotEmpty().MaximumLength(100);
        RuleFor(x => x.HttpMethod).NotEmpty().MaximumLength(10);
        RuleFor(x => x.Endpoint).NotEmpty().MaximumLength(500);
        RuleFor(x => x.ResponseStatusCode).InclusiveBetween(100, 599);
        RuleFor(x => x.ResponseTimeMs).GreaterThanOrEqualTo(0);
        RuleFor(x => x.UserId).GreaterThan(0).When(x => x.UserId.HasValue);
        RuleFor(x => x.IpAddress).MaximumLength(50).When(x => x.IpAddress != null);
    }
}
