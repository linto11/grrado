using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.Vehicles.CreateVehicle;

public class CreateVehicleValidator : AbstractValidator<CreateVehicleRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public CreateVehicleValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
