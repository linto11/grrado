using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.Chatbot.AiImageAnalyses.UpdateAiImageAnalysis;

public class UpdateAiImageAnalysisValidator : AbstractValidator<UpdateAiImageAnalysisRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public UpdateAiImageAnalysisValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;

        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithErrorCode(ErrorCodes.AI_IMAGE_ID_INVALID)
            .WithMessage(GetMessage(ErrorCodes.AI_IMAGE_ID_INVALID, "Invalid aiImageAnalysis ID"));
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
