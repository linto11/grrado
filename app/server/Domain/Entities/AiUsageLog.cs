using Domain.Abstractions;

namespace Domain.Entities;

public class AiUsageLog : IEntity
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string ServiceName { get; set; } = string.Empty; // e.g., "Azure.OpenAI", "Azure.Speech", "Azure.Vision"
    public string ApiEndpoint { get; set; } = string.Empty;
    public string OperationType { get; set; } = string.Empty; // e.g., "text-completion", "speech-to-text", "object-detection"
    
    // Request/Response details
    public int InputTokens { get; set; } = 0;
    public int OutputTokens { get; set; } = 0;
    public int TotalTokens { get; set; } = 0;
    public string? Model { get; set; } // e.g., "gpt-4", "gpt-4-turbo"
    public decimal CostUsd { get; set; } = 0;
    
    // Performance metrics
    public int DurationMs { get; set; } = 0;
    public bool IsSuccessful { get; set; } = true;
    public string? ErrorMessage { get; set; }
    public string? ErrorCode { get; set; }
    
    // Rate limiting & quotas
    public int? RemainingQuotaPercentage { get; set; }
    public DateTime? QuotaResetAt { get; set; }
    
    // Context for tracking
    public string? ConversationId { get; set; } // Foreign reference to chatbot conversation
    public string? MessageId { get; set; } // Foreign reference to chatbot message
    public string? Tags { get; set; } // Comma-separated tags for filtering
    
    // Audit columns
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Soft delete columns
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    
    // Navigation properties
    public User? User { get; set; }
}
