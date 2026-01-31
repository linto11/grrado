namespace Abstractions.DTOs.ChatbotKnowledgeBase;

public class CreateChatbotKnowledgeBaseRequest
{
    public string Category { get; set; } = string.Empty;
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string? Tags { get; set; }
    public string? Synonyms { get; set; }
    public string? RelatedTopics { get; set; }
    public int Priority { get; set; } = 0;
    public bool IsTrainingData { get; set; } = false;
}
