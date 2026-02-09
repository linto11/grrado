using Application.Common.Models;
using Abstractions.DTOs.ChatbotConversation;
using Abstractions.Persistence;
using MediatR;

namespace Application.UseCases.ChatbotConversations.GetAllChatbotConversations;

public class GetAllChatbotConversationsRequest : IRequest<Result<PaginatedResult<ChatbotConversationDto>>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
