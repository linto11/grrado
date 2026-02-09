using Application.Common.Models;
using Abstractions.DTOs.ChatbotKnowledgeBase;
using MediatR;

namespace Application.UseCases.Chatbot.ChatbotKnowledgeBases.UpdateChatbotKnowledgeBase;

public class UpdateChatbotKnowledgeBaseRequest : IRequest<Result<ChatbotKnowledgeBaseDto>>
{
    public int Id { get; set; }
    public string? Category { get; set; }
    public string? Question { get; set; }
    public string? Answer { get; set; }
    public string? Tags { get; set; }
    public string? Synonyms { get; set; }
    public string? RelatedTopics { get; set; }
    public int? Priority { get; set; }
    public bool? IsTrainingData { get; set; }
    public decimal? EffectivenessScore { get; set; }
}
