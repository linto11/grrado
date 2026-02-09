using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.VehicleIssues.CreateVehicleIssue;

public class CreateVehicleIssueValidator : AbstractValidator<CreateVehicleIssueRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public CreateVehicleIssueValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
