using Application.Common.Models;
using Abstractions.DTOs.ChatbotConversation;
using MediatR;

namespace Application.UseCases.ChatbotConversations.CreateChatbotConversation;

public class CreateChatbotConversationRequest : IRequest<Result<ChatbotConversationDto>>
{
    public int UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ConversationMode { get; set; } = "text";
}
