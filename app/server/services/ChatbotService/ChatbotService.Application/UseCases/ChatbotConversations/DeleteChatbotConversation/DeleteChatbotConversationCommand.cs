using GRRADO.Shared.Application.Common;
using MediatR;

namespace ChatbotService.Application.UseCases.ChatbotConversations.DeleteChatbotConversation;

public class DeleteChatbotConversationCommand : IRequest<Result>
{
    public int Id { get; set; }
    public DeleteChatbotConversationCommand(int id) => Id = id;
}
