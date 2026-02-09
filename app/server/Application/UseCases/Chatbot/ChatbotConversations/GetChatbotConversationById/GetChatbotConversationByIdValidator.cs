using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.Chatbot.ChatbotConversations.GetChatbotConversationById;

public class GetChatbotConversationByIdValidator : AbstractValidator<GetChatbotConversationByIdRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public GetChatbotConversationByIdValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;

        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithErrorCode(ErrorCodes.CHATBOT_CONVERSATION_ID_INVALID)
            .WithMessage(GetMessage(ErrorCodes.CHATBOT_CONVERSATION_ID_INVALID, "Invalid chatbotConversation ID"));
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
