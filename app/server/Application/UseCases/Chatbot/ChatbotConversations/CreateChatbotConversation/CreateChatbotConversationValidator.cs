using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.Chatbot.ChatbotConversations.CreateChatbotConversation;

public class CreateChatbotConversationValidator : AbstractValidator<CreateChatbotConversationRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public CreateChatbotConversationValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
