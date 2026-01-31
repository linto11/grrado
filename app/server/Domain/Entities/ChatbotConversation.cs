using Domain.Abstractions;

namespace Domain.Entities;

public class ChatbotConversation : IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Summary { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? EndedAt { get; set; }
    
    // Conversation metadata
    public int MessageCount { get; set; } = 0;
    public decimal TotalTokensUsed { get; set; } = 0;
    public decimal TotalCostUsd { get; set; } = 0;
    public int? SatisfactionRating { get; set; } // 1-5 stars
    public string? SatisfactionComment { get; set; }
    
    // Conversation mode/context
    public string ConversationMode { get; set; } = "text"; // text, voice, image, deep-thinking
    public bool IsArchived { get; set; } = false;
    
    // Audit columns
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Soft delete columns
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    
    // Navigation properties
    public User? User { get; set; }
    public ICollection<ChatbotMessage> Messages { get; set; } = new List<ChatbotMessage>();
}
