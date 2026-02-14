using GRRADO.Shared.Application.Common;
using MediatR;
using ChatbotService.Application.DTOs;

namespace ChatbotService.Application.UseCases.ChatbotConversations.CreateChatbotConversation;

public class CreateChatbotConversationCommand : IRequest<Result<ChatbotConversationDto>>
{
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
}
