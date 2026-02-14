namespace LoggingService.Application.DTOs;

public class CreateErrorMessageRequest
{
    public Guid Code { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string? UseCase { get; set; }
    public string? LocaleCode { get; set; } = "en-US";
}
