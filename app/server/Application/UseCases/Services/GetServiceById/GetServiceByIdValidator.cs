using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.Services.GetServiceById;

public class GetServiceByIdValidator : AbstractValidator<GetServiceByIdRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public GetServiceByIdValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;

        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithErrorCode(ErrorCodes.SERVICE_ID_INVALID)
            .WithMessage(GetMessage(ErrorCodes.SERVICE_ID_INVALID, "Invalid service ID"));
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
