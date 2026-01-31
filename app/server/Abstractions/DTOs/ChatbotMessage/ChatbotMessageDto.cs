namespace Abstractions.DTOs.ChatbotMessage;

public class ChatbotMessageDto
{
    public int Id { get; set; }
    public int ConversationId { get; set; }
    public int UserId { get; set; }
    public string UserMessage { get; set; } = string.Empty;
    public string BotResponse { get; set; } = string.Empty;
    public string MessageType { get; set; } = string.Empty;
    public int TokensUsed { get; set; }
    public decimal CostUsd { get; set; }
    public string? DetectedIntent { get; set; }
    public decimal? ConfidenceScore { get; set; }
    public string? ExtractionEntities { get; set; }
    public int? ResponseTimeMs { get; set; }
    public bool IsThinkingMode { get; set; }
    public string? ThinkingProcess { get; set; }
    public bool? IsHelpful { get; set; }
    public string? UserFeedback { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
