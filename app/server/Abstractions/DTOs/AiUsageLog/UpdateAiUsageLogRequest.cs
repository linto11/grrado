namespace Abstractions.DTOs.AiUsageLog;

public class UpdateAiUsageLogRequest
{
    public int? RemainingQuotaPercentage { get; set; }
    public DateTime? QuotaResetAt { get; set; }
}
