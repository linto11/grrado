using Application.Common.Models;
using MediatR;

namespace Application.UseCases.ChatbotKnowledgeBases.DeleteChatbotKnowledgeBase;

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
