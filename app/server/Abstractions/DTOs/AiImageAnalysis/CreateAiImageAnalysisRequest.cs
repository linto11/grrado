namespace Abstractions.DTOs.AiImageAnalysis;

public class CreateAiImageAnalysisRequest
{
    public int ChatbotMessageId { get; set; }
    public int UserId { get; set; }
    public string OriginalImageFileName { get; set; } = string.Empty;
    public string OriginalImagePath { get; set; } = string.Empty;
    public long FileSizeBytes { get; set; }
    public string ImageMimeType { get; set; } = string.Empty;
    public string AnalysisType { get; set; } = string.Empty;
}
