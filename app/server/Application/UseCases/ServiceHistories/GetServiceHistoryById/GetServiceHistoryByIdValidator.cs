using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.ServiceHistories.GetServiceHistoryById;

public class GetServiceHistoryByIdValidator : AbstractValidator<GetServiceHistoryByIdRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public GetServiceHistoryByIdValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;

        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithErrorCode(ErrorCodes.SERVICE_HISTORY_ID_INVALID)
            .WithMessage(GetMessage(ErrorCodes.SERVICE_HISTORY_ID_INVALID, "Invalid serviceHistory ID"));
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
