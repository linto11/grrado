using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.Core.Services.CreateService;

public class CreateServiceValidator : AbstractValidator<CreateServiceRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public CreateServiceValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
