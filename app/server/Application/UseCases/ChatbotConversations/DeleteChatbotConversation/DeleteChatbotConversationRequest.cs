using Application.Common.Models;
using MediatR;

namespace Application.UseCases.ChatbotConversations.DeleteChatbotConversation;

public class DeleteChatbotConversationRequest : IRequest<Result>
{
    public int Id { get; set; }

    public DeleteChatbotConversationRequest(int id)
    {
        Id = id;
    }

    public DeleteChatbotConversationRequest()
    {
    }
}
