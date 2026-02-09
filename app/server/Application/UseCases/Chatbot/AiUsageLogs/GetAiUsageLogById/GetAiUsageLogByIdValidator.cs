using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.Chatbot.AiUsageLogs.GetAiUsageLogById;

public class GetAiUsageLogByIdValidator : AbstractValidator<GetAiUsageLogByIdRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public GetAiUsageLogByIdValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;

        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithErrorCode(ErrorCodes.AI_USAGE_ID_INVALID)
            .WithMessage(GetMessage(ErrorCodes.AI_USAGE_ID_INVALID, "Invalid aiUsageLog ID"));
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
