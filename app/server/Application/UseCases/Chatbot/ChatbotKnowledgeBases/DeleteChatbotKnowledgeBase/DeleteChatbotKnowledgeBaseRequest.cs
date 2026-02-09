using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Chatbot.ChatbotKnowledgeBases.DeleteChatbotKnowledgeBase;

public class DeleteChatbotKnowledgeBaseRequest : IRequest<Result>
{
    public int Id { get; set; }

    public DeleteChatbotKnowledgeBaseRequest(int id)
    {
        Id = id;
    }

    public DeleteChatbotKnowledgeBaseRequest()
    {
    }
}
