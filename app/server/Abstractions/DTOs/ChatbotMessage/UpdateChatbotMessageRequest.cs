namespace Abstractions.DTOs.ChatbotMessage;

public class UpdateChatbotMessageRequest
{
    public bool? IsHelpful { get; set; }
    public string? UserFeedback { get; set; }
}
