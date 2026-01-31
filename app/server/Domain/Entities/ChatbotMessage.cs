using Domain.Abstractions;

namespace Domain.Entities;

public class ChatbotMessage : IEntity
{
    public int Id { get; set; }
    public int ConversationId { get; set; }
    public int UserId { get; set; }
    
    // Message content
    public string UserMessage { get; set; } = string.Empty;
    public string BotResponse { get; set; } = string.Empty;
    
    // Message metadata
    public string MessageType { get; set; } = "text"; // text, voice, image, deep-thinking
    public int TokensUsed { get; set; } = 0;
    public decimal CostUsd { get; set; } = 0;
    
    // Intent and context
    public string? DetectedIntent { get; set; }
    public decimal? ConfidenceScore { get; set; } // 0-1
    public string? ExtractionEntities { get; set; } // JSON string of extracted entities
    
    // Response metadata
    public int? ResponseTimeMs { get; set; } // Response latency in milliseconds
    public bool IsThinkingMode { get; set; } = false;
    public string? ThinkingProcess { get; set; } // JSON string for deep thinking steps
    
    // User feedback
    public bool? IsHelpful { get; set; } // Thumbs up/down
    public string? UserFeedback { get; set; }
    
    // Audit columns
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Soft delete columns
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    
    // Navigation properties
    public ChatbotConversation? Conversation { get; set; }
    public User? User { get; set; }
    public ICollection<AiImageAnalysis> ImageAnalyses { get; set; } = new List<AiImageAnalysis>();
}
