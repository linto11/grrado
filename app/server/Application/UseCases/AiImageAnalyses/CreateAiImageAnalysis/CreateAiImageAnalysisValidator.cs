using FluentValidation;
using Abstractions.Services;
using Application.Common.Constants;

namespace Application.UseCases.AiImageAnalyses.CreateAiImageAnalysis;

public class CreateAiImageAnalysisValidator : AbstractValidator<CreateAiImageAnalysisRequest>
{
    private readonly IErrorMessageService _errorMessageService;

    public CreateAiImageAnalysisValidator(IErrorMessageService errorMessageService)
    {
        _errorMessageService = errorMessageService;
    }

    private string GetMessage(string code, string defaultMessage)
    {
        return _errorMessageService.GetMessageAsync(code, defaultMessage).GetAwaiter().GetResult();
    }
}
