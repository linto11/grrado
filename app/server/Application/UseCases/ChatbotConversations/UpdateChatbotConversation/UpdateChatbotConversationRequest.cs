using Application.Common.Models;
using Abstractions.DTOs.ChatbotConversation;
using MediatR;

namespace Application.UseCases.ChatbotConversations.UpdateChatbotConversation;

public class UpdateChatbotConversationRequest : IRequest<Result<ChatbotConversationDto>>
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Summary { get; set; }
    public DateTime? EndedAt { get; set; }
    public int? SatisfactionRating { get; set; }
    public string? SatisfactionComment { get; set; }
    public bool? IsArchived { get; set; }
}
