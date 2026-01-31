using Domain.Abstractions;

namespace Domain.Entities;

public class ChatbotKnowledgeBase : IEntity
{
    public int Id { get; set; }
    public string Category { get; set; } = string.Empty; // e.g., "OBD Codes", "Services", "Diagnostics", "Common Issues"
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string? Tags { get; set; } // Comma-separated tags for searching
    
    // Knowledge base metadata
    public int UsageCount { get; set; } = 0; // How many times referenced
    public decimal EffectivenessScore { get; set; } = 0; // 0-1, based on user feedback
    public string? EmbeddingVector { get; set; } // Stored as JSON or vector format
    
    // Content metadata
    public string? Synonyms { get; set; } // JSON array of alternative phrasings
    public string? RelatedTopics { get; set; } // Comma-separated topic IDs
    public int Priority { get; set; } = 0; // Higher = more likely to be retrieved
    
    // Training data
    public bool IsTrainingData { get; set; } = false; // Used for model training
    public int? ModelVersionUsedFor { get; set; } // Which model version used this
    public decimal? Confidence { get; set; } // Confidence score for this knowledge item
    
    // Audit columns
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Soft delete columns
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
