namespace Abstractions.DTOs.ChatbotKnowledgeBase;

public class ChatbotKnowledgeBaseDto
{
    public int Id { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string? Tags { get; set; }
    public int UsageCount { get; set; }
    public decimal EffectivenessScore { get; set; }
    public string? Synonyms { get; set; }
    public string? RelatedTopics { get; set; }
    public int Priority { get; set; }
    public bool IsTrainingData { get; set; }
    public int? ModelVersionUsedFor { get; set; }
    public decimal? Confidence { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
