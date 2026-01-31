namespace Abstractions.DTOs.AiUsageLog;

public class AiUsageLogDto
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string ServiceName { get; set; } = string.Empty;
    public string ApiEndpoint { get; set; } = string.Empty;
    public string OperationType { get; set; } = string.Empty;
    public int InputTokens { get; set; }
    public int OutputTokens { get; set; }
    public int TotalTokens { get; set; }
    public string? Model { get; set; }
    public decimal CostUsd { get; set; }
    public int DurationMs { get; set; }
    public bool IsSuccessful { get; set; }
    public string? ErrorMessage { get; set; }
    public string? ErrorCode { get; set; }
    public int? RemainingQuotaPercentage { get; set; }
    public DateTime? QuotaResetAt { get; set; }
    public string? ConversationId { get; set; }
    public string? MessageId { get; set; }
    public string? Tags { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
