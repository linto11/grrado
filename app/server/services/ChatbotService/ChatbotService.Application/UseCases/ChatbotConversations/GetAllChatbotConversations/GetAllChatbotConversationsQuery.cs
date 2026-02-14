using GRRADO.Shared.Application.Common;
using MediatR;
using ChatbotService.Application.DTOs;

namespace ChatbotService.Application.UseCases.ChatbotConversations.GetAllChatbotConversations;

public class GetAllChatbotConversationsQuery : IRequest<Result<List<ChatbotConversationDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
