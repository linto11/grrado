namespace Abstractions.DTOs.ChatbotConversation;

public class UpdateChatbotConversationRequest
{
    public string? Title { get; set; }
    public string? Summary { get; set; }
    public DateTime? EndedAt { get; set; }
    public int? SatisfactionRating { get; set; }
    public string? SatisfactionComment { get; set; }
    public bool? IsArchived { get; set; }
}
