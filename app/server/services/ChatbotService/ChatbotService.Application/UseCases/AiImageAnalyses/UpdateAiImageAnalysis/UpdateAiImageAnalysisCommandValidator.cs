using FluentValidation;

namespace ChatbotService.Application.UseCases.AiImageAnalyses.UpdateAiImageAnalysis;

public class UpdateAiImageAnalysisCommandValidator : AbstractValidator<UpdateAiImageAnalysisCommand>
{
    public UpdateAiImageAnalysisCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.ChatbotMessageId).GreaterThan(0);
        RuleFor(x => x.UserId).GreaterThan(0);
        RuleFor(x => x.OriginalImageFileName).NotEmpty().MaximumLength(500);
        RuleFor(x => x.OriginalImagePath).NotEmpty().MaximumLength(1000);
        RuleFor(x => x.FileSizeBytes).GreaterThan(0);
        RuleFor(x => x.ImageMimeType).NotEmpty().MaximumLength(100);
        RuleFor(x => x.AnalysisType).NotEmpty().MaximumLength(100);
        RuleFor(x => x.DetectedObjects).NotEmpty();
        RuleFor(x => x.ConfidenceScore).InclusiveBetween(0, 1).When(x => x.ConfidenceScore.HasValue);
        RuleFor(x => x.ResponseTimeMs).GreaterThanOrEqualTo(0);
        RuleFor(x => x.TokensUsed).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CostUsd).GreaterThanOrEqualTo(0);
    }
}
