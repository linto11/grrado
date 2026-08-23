using FluentValidation;

namespace ChatbotService.Application.UseCases.ChatbotMessages.UpdateChatbotMessage;

public class UpdateChatbotMessageCommandValidator : AbstractValidator<UpdateChatbotMessageCommand>
{
    public UpdateChatbotMessageCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.ConversationId).GreaterThan(0);
        RuleFor(x => x.UserId).GreaterThan(0);
        RuleFor(x => x.UserMessage).NotEmpty().MaximumLength(10000);
        RuleFor(x => x.BotResponse).NotEmpty().MaximumLength(50000);
        RuleFor(x => x.MessageType).NotEmpty().MaximumLength(50);
        RuleFor(x => x.TokensUsed).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CostUsd).GreaterThanOrEqualTo(0);
        RuleFor(x => x.ConfidenceScore).InclusiveBetween(0, 1).When(x => x.ConfidenceScore.HasValue);
        RuleFor(x => x.ResponseTimeMs).GreaterThanOrEqualTo(0).When(x => x.ResponseTimeMs.HasValue);
    }
}
