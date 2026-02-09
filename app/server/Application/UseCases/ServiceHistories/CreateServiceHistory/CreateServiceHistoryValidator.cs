using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.ServiceHistories.CreateServiceHistory;

public class CreateServiceHistoryValidator : AbstractValidator<CreateServiceHistoryRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public CreateServiceHistoryValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
