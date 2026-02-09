using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.ChatbotKnowledgeBases.UpdateChatbotKnowledgeBase;

public class UpdateChatbotKnowledgeBaseValidator : AbstractValidator<UpdateChatbotKnowledgeBaseRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public UpdateChatbotKnowledgeBaseValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;

        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithErrorCode(ErrorCodes.CHATBOT_KB_ID_INVALID)
            .WithMessage(GetMessage(ErrorCodes.CHATBOT_KB_ID_INVALID, "Invalid chatbotKnowledgeBase ID"));
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
