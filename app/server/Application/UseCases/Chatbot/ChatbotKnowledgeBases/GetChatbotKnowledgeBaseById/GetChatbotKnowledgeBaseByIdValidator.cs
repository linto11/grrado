using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.Chatbot.ChatbotKnowledgeBases.GetChatbotKnowledgeBaseById;

public class GetChatbotKnowledgeBaseByIdValidator : AbstractValidator<GetChatbotKnowledgeBaseByIdRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public GetChatbotKnowledgeBaseByIdValidator(IErrorMessageService errorMessageService)
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
