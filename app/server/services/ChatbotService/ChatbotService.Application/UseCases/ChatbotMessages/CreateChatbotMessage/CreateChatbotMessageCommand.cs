using GRRADO.Shared.Application.Common;
using MediatR;
using ChatbotService.Application.DTOs;

namespace ChatbotService.Application.UseCases.ChatbotMessages.CreateChatbotMessage;

public class CreateChatbotMessageCommand : IRequest<Result<ChatbotMessageDto>>
{
    public int ConversationId { get; set; }
    public int UserId { get; set; }
    public string UserMessage { get; set; } = string.Empty;
    public string BotResponse { get; set; } = string.Empty;
    public string MessageType { get; set; } = "text";
    public int TokensUsed { get; set; } = 0;
    public decimal CostUsd { get; set; } = 0;
    public string? DetectedIntent { get; set; }
    public decimal? ConfidenceScore { get; set; }
    public string? ExtractionEntities { get; set; }
    public int? ResponseTimeMs { get; set; }
    public bool IsThinkingMode { get; set; } = false;
    public string? ThinkingProcess { get; set; }
    public bool? IsHelpful { get; set; }
    public string? UserFeedback { get; set; }
}
