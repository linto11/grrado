using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.AiUsageLogs.CreateAiUsageLog;

public class CreateAiUsageLogValidator : AbstractValidator<CreateAiUsageLogRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public CreateAiUsageLogValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
