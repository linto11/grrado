using GRRADO.Shared.Domain;

namespace ChatbotService.Domain.Entities;

public class ChatbotConversation : IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Summary { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? EndedAt { get; set; }
    public int MessageCount { get; set; } = 0;
    public decimal TotalTokensUsed { get; set; } = 0;
    public decimal TotalCostUsd { get; set; } = 0;
    public int? SatisfactionRating { get; set; }
    public string? SatisfactionComment { get; set; }
    public string ConversationMode { get; set; } = "text";
    public bool IsArchived { get; set; } = false;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }

    public ICollection<ChatbotMessage> Messages { get; set; } = new List<ChatbotMessage>();
}
