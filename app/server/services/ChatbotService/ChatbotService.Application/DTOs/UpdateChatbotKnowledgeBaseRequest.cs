namespace ChatbotService.Application.DTOs;

public class UpdateChatbotKnowledgeBaseRequest
{
    public string Category { get; set; } = string.Empty;
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string? Tags { get; set; }
    public int UsageCount { get; set; }
    public decimal EffectivenessScore { get; set; }
    public string? EmbeddingVector { get; set; }
    public string? Synonyms { get; set; }
    public string? RelatedTopics { get; set; }
    public int Priority { get; set; }
    public bool IsTrainingData { get; set; }
    public int? ModelVersionUsedFor { get; set; }
    public decimal? Confidence { get; set; }
}
