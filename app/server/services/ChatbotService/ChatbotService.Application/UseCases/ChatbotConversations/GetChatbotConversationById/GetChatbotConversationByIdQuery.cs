using GRRADO.Shared.Application.Common;
using MediatR;
using ChatbotService.Application.DTOs;

namespace ChatbotService.Application.UseCases.ChatbotConversations.GetChatbotConversationById;

public class GetChatbotConversationByIdQuery : IRequest<Result<ChatbotConversationDto>>
{
    public int Id { get; set; }
    public GetChatbotConversationByIdQuery(int id) => Id = id;
}
