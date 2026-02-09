using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.ChatbotMessages.UpdateChatbotMessage;

public class UpdateChatbotMessageValidator : AbstractValidator<UpdateChatbotMessageRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public UpdateChatbotMessageValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;

        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithErrorCode(ErrorCodes.CHATBOT_MESSAGE_ID_INVALID)
            .WithMessage(GetMessage(ErrorCodes.CHATBOT_MESSAGE_ID_INVALID, "Invalid chatbotMessage ID"));
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
