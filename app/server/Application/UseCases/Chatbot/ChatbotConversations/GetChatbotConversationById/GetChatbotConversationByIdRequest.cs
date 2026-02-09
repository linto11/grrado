using Application.Common.Models;
using Abstractions.DTOs.ChatbotConversation;
using MediatR;

namespace Application.UseCases.Chatbot.ChatbotConversations.GetChatbotConversationById;

public class GetChatbotConversationByIdRequest : IRequest<Result<ChatbotConversationDto>>
{
    public int Id { get; set; }

    public GetChatbotConversationByIdRequest(int id)
    {
        Id = id;
    }

    public GetChatbotConversationByIdRequest()
    {
    }
}
