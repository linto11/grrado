using Application.Common.Models;
using Abstractions.DTOs.ChatbotKnowledgeBase;
using Abstractions.Persistence;
using MediatR;

namespace Application.UseCases.ChatbotKnowledgeBases.GetAllChatbotKnowledgeBases;

public class GetAllChatbotKnowledgeBasesRequest : IRequest<Result<PaginatedResult<ChatbotKnowledgeBaseDto>>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
