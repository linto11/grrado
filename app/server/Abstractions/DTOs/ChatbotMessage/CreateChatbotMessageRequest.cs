namespace Abstractions.DTOs.ChatbotMessage;

public class CreateChatbotMessageRequest
{
    public int ConversationId { get; set; }
    public int UserId { get; set; }
    public string UserMessage { get; set; } = string.Empty;
    public string MessageType { get; set; } = "text"; // text, voice, image, deep-thinking
    public bool IsThinkingMode { get; set; } = false;
}
