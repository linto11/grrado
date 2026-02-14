using GRRADO.Shared.Domain;

namespace ChatbotService.Domain.Entities;

public class ChatbotMessage : IEntity
{
    public int Id { get; set; }
    public int ConversationId { get; set; }
    public int UserId { get; set; }
    public string UserMessage { get; set; } = string.Empty;
    public string BotResponse { get; set; } = string.Empty;
    public string MessageType { get; set; } = "text";
    public int TokensUsed { get; set; } = 0;
    public decimal CostUsd { get; set; } = 0;
    public string? DetectedIntent { get; set; }
    public decimal? ConfidenceScore { get; set; }
    public string? ExtractionEntities { get; set; }
    public int? ResponseTimeMs { get; set; }
    public bool IsThinkingMode { get; set; } = false;
    public string? ThinkingProcess { get; set; }
    public bool? IsHelpful { get; set; }
    public string? UserFeedback { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }

    public ChatbotConversation? Conversation { get; set; }
    public ICollection<AiImageAnalysis> ImageAnalyses { get; set; } = new List<AiImageAnalysis>();
}
