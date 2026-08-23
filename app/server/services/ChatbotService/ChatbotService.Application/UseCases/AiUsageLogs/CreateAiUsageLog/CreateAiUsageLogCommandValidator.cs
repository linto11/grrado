using FluentValidation;

namespace ChatbotService.Application.UseCases.AiUsageLogs.CreateAiUsageLog;

public class CreateAiUsageLogCommandValidator : AbstractValidator<CreateAiUsageLogCommand>
{
    public CreateAiUsageLogCommandValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0).When(x => x.UserId.HasValue);
        RuleFor(x => x.ServiceName).NotEmpty().MaximumLength(200);
        RuleFor(x => x.ApiEndpoint).NotEmpty().MaximumLength(500);
        RuleFor(x => x.OperationType).NotEmpty().MaximumLength(100);
        RuleFor(x => x.InputTokens).GreaterThanOrEqualTo(0);
        RuleFor(x => x.OutputTokens).GreaterThanOrEqualTo(0);
        RuleFor(x => x.TotalTokens).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CostUsd).GreaterThanOrEqualTo(0);
        RuleFor(x => x.DurationMs).GreaterThanOrEqualTo(0);
    }
}
