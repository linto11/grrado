namespace LoggingService.Application.DTOs;

public class ErrorLogDto
{
    public int Id { get; set; }
    public string ErrorCode { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    public string StackTrace { get; set; } = string.Empty;
    public string? InnerException { get; set; }
    public string Source { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public int? UserId { get; set; }
    public string? RequestId { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
    public string? Metadata { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
