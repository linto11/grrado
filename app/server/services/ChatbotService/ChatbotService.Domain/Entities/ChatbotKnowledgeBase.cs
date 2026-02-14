using GRRADO.Shared.Domain;

namespace ChatbotService.Domain.Entities;

public class ChatbotKnowledgeBase : IEntity
{
    public int Id { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string? Tags { get; set; }
    public int UsageCount { get; set; } = 0;
    public decimal EffectivenessScore { get; set; } = 0;
    public string? EmbeddingVector { get; set; }
    public string? Synonyms { get; set; }
    public string? RelatedTopics { get; set; }
    public int Priority { get; set; } = 0;
    public bool IsTrainingData { get; set; } = false;
    public int? ModelVersionUsedFor { get; set; }
    public decimal? Confidence { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
