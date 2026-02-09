using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.Core.VehicleIssues.DeleteVehicleIssue;

public class DeleteVehicleIssueValidator : AbstractValidator<DeleteVehicleIssueRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public DeleteVehicleIssueValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;

        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithErrorCode(ErrorCodes.VEHICLE_ISSUE_ID_INVALID)
            .WithMessage(GetMessage(ErrorCodes.VEHICLE_ISSUE_ID_INVALID, "Invalid vehicleIssue ID"));
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
