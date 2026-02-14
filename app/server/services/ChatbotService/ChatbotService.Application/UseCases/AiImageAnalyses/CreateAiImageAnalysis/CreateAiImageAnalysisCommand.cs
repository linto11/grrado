using GRRADO.Shared.Application.Common;
using MediatR;
using ChatbotService.Application.DTOs;

namespace ChatbotService.Application.UseCases.AiImageAnalyses.CreateAiImageAnalysis;

public class CreateAiImageAnalysisCommand : IRequest<Result<AiImageAnalysisDto>>
{
    public int ChatbotMessageId { get; set; }
    public int UserId { get; set; }
    public string OriginalImageFileName { get; set; } = string.Empty;
    public string OriginalImagePath { get; set; } = string.Empty;
    public string? AnnotatedImagePath { get; set; }
    public string? ThumbnailPath { get; set; }
    public long FileSizeBytes { get; set; }
    public string ImageMimeType { get; set; } = string.Empty;
    public string AnalysisType { get; set; } = string.Empty;
    public string DetectedObjects { get; set; } = string.Empty;
    public string? SeverityLevel { get; set; }
    public string? DamageType { get; set; }
    public string? PartsIdentified { get; set; }
    public decimal? ConfidenceScore { get; set; }
    public string? Recommendations { get; set; }
    public string? VehiclePartLocation { get; set; }
    public int? EstimatedRepairCostRange { get; set; }
    public bool RequiresExpertReview { get; set; } = false;
    public int ResponseTimeMs { get; set; } = 0;
    public int TokensUsed { get; set; } = 0;
    public decimal CostUsd { get; set; } = 0;
}
