using FluentValidation;

namespace ChatbotService.Application.UseCases.ChatbotConversations.UpdateChatbotConversation;

public class UpdateChatbotConversationCommandValidator : AbstractValidator<UpdateChatbotConversationCommand>
{
    public UpdateChatbotConversationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.UserId).GreaterThan(0);
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Summary).MaximumLength(2000).When(x => x.Summary != null);
        RuleFor(x => x.MessageCount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.TotalTokensUsed).GreaterThanOrEqualTo(0);
        RuleFor(x => x.TotalCostUsd).GreaterThanOrEqualTo(0);
        RuleFor(x => x.SatisfactionRating).InclusiveBetween(1, 5).When(x => x.SatisfactionRating.HasValue);
        RuleFor(x => x.ConversationMode).NotEmpty().MaximumLength(50);
    }
}
