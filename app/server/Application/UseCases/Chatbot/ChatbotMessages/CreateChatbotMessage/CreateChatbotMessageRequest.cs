using Application.Common.Models;
using Abstractions.DTOs.ChatbotMessage;
using MediatR;

namespace Application.UseCases.Chatbot.ChatbotMessages.CreateChatbotMessage;

public class CreateChatbotMessageRequest : IRequest<Result<ChatbotMessageDto>>
{
    public int ConversationId { get; set; }
    public int UserId { get; set; }
    public string UserMessage { get; set; } = string.Empty;
    public string MessageType { get; set; } = "text";
    public bool IsThinkingMode { get; set; }
}
