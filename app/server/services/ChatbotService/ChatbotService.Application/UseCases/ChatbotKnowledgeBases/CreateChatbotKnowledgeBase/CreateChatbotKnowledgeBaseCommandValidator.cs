using FluentValidation;

namespace ChatbotService.Application.UseCases.ChatbotKnowledgeBases.CreateChatbotKnowledgeBase;

public class CreateChatbotKnowledgeBaseCommandValidator : AbstractValidator<CreateChatbotKnowledgeBaseCommand>
{
    public CreateChatbotKnowledgeBaseCommandValidator()
    {
        RuleFor(x => x.Category).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Question).NotEmpty().MaximumLength(1000);
        RuleFor(x => x.Answer).NotEmpty().MaximumLength(10000);
        RuleFor(x => x.UsageCount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.EffectivenessScore).InclusiveBetween(0, 100);
        RuleFor(x => x.Priority).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Confidence).InclusiveBetween(0, 1).When(x => x.Confidence.HasValue);
    }
}
