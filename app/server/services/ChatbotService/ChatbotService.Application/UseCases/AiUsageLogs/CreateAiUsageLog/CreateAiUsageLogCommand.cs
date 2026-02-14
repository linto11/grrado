using GRRADO.Shared.Application.Common;
using ChatbotService.Application.DTOs;
using MediatR;

namespace ChatbotService.Application.UseCases.AiUsageLogs.CreateAiUsageLog;

public class CreateAiUsageLogCommand : IRequest<Result<AiUsageLogDto>>
{
    public int? UserId { get; set; }
    public string ServiceName { get; set; } = string.Empty;
    public string ApiEndpoint { get; set; } = string.Empty;
    public string OperationType { get; set; } = string.Empty;
    public int InputTokens { get; set; } = 0;
    public int OutputTokens { get; set; } = 0;
    public int TotalTokens { get; set; } = 0;
    public string? Model { get; set; }
    public decimal CostUsd { get; set; } = 0;
    public int DurationMs { get; set; } = 0;
    public bool IsSuccessful { get; set; } = true;
    public string? ErrorMessage { get; set; }
    public string? ErrorCode { get; set; }
    public int? RemainingQuotaPercentage { get; set; }
    public DateTime? QuotaResetAt { get; set; }
    public string? ConversationId { get; set; }
    public string? MessageId { get; set; }
    public string? Tags { get; set; }
}
