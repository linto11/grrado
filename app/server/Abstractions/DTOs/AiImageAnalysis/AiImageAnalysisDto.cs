namespace Abstractions.DTOs.AiImageAnalysis;

public class AiImageAnalysisDto
{
    public int Id { get; set; }
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
    public bool RequiresExpertReview { get; set; }
    public int ResponseTimeMs { get; set; }
    public int TokensUsed { get; set; }
    public decimal CostUsd { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
