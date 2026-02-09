using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.Vehicles.DeleteVehicle;

public class DeleteVehicleValidator : AbstractValidator<DeleteVehicleRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public DeleteVehicleValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;

        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithErrorCode(ErrorCodes.VEHICLE_ID_INVALID)
            .WithMessage(GetMessage(ErrorCodes.VEHICLE_ID_INVALID, "Invalid vehicle ID"));
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
