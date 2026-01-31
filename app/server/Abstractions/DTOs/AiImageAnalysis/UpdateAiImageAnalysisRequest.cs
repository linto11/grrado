namespace Abstractions.DTOs.AiImageAnalysis;

public class UpdateAiImageAnalysisRequest
{
    public string? AnnotatedImagePath { get; set; }
    public string? SeverityLevel { get; set; }
    public string? DamageType { get; set; }
    public string? PartsIdentified { get; set; }
    public decimal? ConfidenceScore { get; set; }
    public string? Recommendations { get; set; }
    public string? VehiclePartLocation { get; set; }
    public int? EstimatedRepairCostRange { get; set; }
    public bool? RequiresExpertReview { get; set; }
}
