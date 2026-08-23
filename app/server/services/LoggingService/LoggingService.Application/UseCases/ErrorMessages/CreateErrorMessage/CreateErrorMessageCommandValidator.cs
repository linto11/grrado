using FluentValidation;

namespace LoggingService.Application.UseCases.ErrorMessages.CreateErrorMessage;

public class CreateErrorMessageCommandValidator : AbstractValidator<CreateErrorMessageCommand>
{
    public CreateErrorMessageCommandValidator()
    {
        RuleFor(x => x.Code).NotEmpty();
        RuleFor(x => x.Message).NotEmpty().MaximumLength(2000);
        RuleFor(x => x.Category).NotEmpty().MaximumLength(100);
        RuleFor(x => x.UseCase).MaximumLength(200).When(x => x.UseCase != null);
        RuleFor(x => x.LocaleCode).MaximumLength(10).When(x => x.LocaleCode != null);
    }
}
