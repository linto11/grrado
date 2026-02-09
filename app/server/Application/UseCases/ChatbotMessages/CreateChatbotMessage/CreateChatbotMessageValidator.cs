using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.ChatbotMessages.CreateChatbotMessage;

public class CreateChatbotMessageValidator : AbstractValidator<CreateChatbotMessageRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public CreateChatbotMessageValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
