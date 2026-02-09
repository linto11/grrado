using Application.Common.Models;
using Abstractions.DTOs.ChatbotKnowledgeBase;
using MediatR;

namespace Application.UseCases.Chatbot.ChatbotKnowledgeBases.CreateChatbotKnowledgeBase;

public class CreateChatbotKnowledgeBaseRequest : IRequest<Result<ChatbotKnowledgeBaseDto>>
{
    public string Category { get; set; } = string.Empty;
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string? Tags { get; set; }
    public string? Synonyms { get; set; }
    public string? RelatedTopics { get; set; }
    public int Priority { get; set; }
    public bool IsTrainingData { get; set; }
}
