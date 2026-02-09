using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.Core.Garages.DeleteGarage;

public class DeleteGarageValidator : AbstractValidator<DeleteGarageRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public DeleteGarageValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;

        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithErrorCode(ErrorCodes.GARAGE_ID_INVALID)
            .WithMessage(GetMessage(ErrorCodes.GARAGE_ID_INVALID, "Invalid garage ID"));
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
