namespace Abstractions.DTOs.ChatbotKnowledgeBase;

public class UpdateChatbotKnowledgeBaseRequest
{
    public string? Category { get; set; }
    public string? Question { get; set; }
    public string? Answer { get; set; }
    public string? Tags { get; set; }
    public string? Synonyms { get; set; }
    public string? RelatedTopics { get; set; }
    public int? Priority { get; set; }
    public bool? IsTrainingData { get; set; }
    public decimal? EffectivenessScore { get; set; }
}
