using Application.Common.Models;
using Abstractions.DTOs.ChatbotKnowledgeBase;
using MediatR;

namespace Application.UseCases.Chatbot.ChatbotKnowledgeBases.GetChatbotKnowledgeBaseById;

public class GetChatbotKnowledgeBaseByIdRequest : IRequest<Result<ChatbotKnowledgeBaseDto>>
{
    public int Id { get; set; }

    public GetChatbotKnowledgeBaseByIdRequest(int id)
    {
        Id = id;
    }

    public GetChatbotKnowledgeBaseByIdRequest()
    {
    }
}
