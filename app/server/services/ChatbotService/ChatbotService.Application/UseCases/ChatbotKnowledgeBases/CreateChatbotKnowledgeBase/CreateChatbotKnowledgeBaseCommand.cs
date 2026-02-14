using GRRADO.Shared.Application.Common;
using MediatR;
using ChatbotService.Application.DTOs;

namespace ChatbotService.Application.UseCases.ChatbotKnowledgeBases.CreateChatbotKnowledgeBase;

public class CreateChatbotKnowledgeBaseCommand : IRequest<Result<ChatbotKnowledgeBaseDto>>
{
    public string Category { get; set; } = string.Empty;
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string? Tags { get; set; }
    public int UsageCount { get; set; } = 0;
    public decimal EffectivenessScore { get; set; } = 0;
    public string? EmbeddingVector { get; set; }
    public string? Synonyms { get; set; }
    public string? RelatedTopics { get; set; }
    public int Priority { get; set; } = 0;
    public bool IsTrainingData { get; set; } = false;
    public int? ModelVersionUsedFor { get; set; }
    public decimal? Confidence { get; set; }
}
