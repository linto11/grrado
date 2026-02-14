using GRRADO.Shared.Application.Common;
using MediatR;
using ChatbotService.Application.DTOs;

namespace ChatbotService.Application.UseCases.ChatbotKnowledgeBases.GetAllChatbotKnowledgeBases;

public class GetAllChatbotKnowledgeBasesQuery : IRequest<Result<List<ChatbotKnowledgeBaseDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
