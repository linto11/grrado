namespace Abstractions.DTOs.ChatbotConversation;

public class CreateChatbotConversationRequest
{
    public int UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ConversationMode { get; set; } = "text"; // text, voice, image, deep-thinking
}
