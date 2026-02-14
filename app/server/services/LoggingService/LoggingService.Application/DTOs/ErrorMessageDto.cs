namespace LoggingService.Application.DTOs;

public class ErrorMessageDto
{
    public int Id { get; set; }
    public Guid Code { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string? UseCase { get; set; }
    public string? LocaleCode { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
