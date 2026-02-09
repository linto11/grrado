using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.Garages.CreateGarage;

public class CreateGarageValidator : AbstractValidator<CreateGarageRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public CreateGarageValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
