namespace LoggingService.Application.DTOs;

public class UpdateErrorMessageRequest
{
    public Guid Code { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string? UseCase { get; set; }
    public string? LocaleCode { get; set; }
}
