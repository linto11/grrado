using GRRADO.Shared.Application.Common;
using MediatR;
using ChatbotService.Application.DTOs;

namespace ChatbotService.Application.UseCases.ChatbotKnowledgeBases.GetChatbotKnowledgeBaseById;

public class GetChatbotKnowledgeBaseByIdQuery : IRequest<Result<ChatbotKnowledgeBaseDto>>
{
    public int Id { get; set; }
    public GetChatbotKnowledgeBaseByIdQuery(int id) => Id = id;
}
