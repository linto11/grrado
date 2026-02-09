using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.Chatbot.ChatbotKnowledgeBases.CreateChatbotKnowledgeBase;

public class CreateChatbotKnowledgeBaseValidator : AbstractValidator<CreateChatbotKnowledgeBaseRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public CreateChatbotKnowledgeBaseValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
