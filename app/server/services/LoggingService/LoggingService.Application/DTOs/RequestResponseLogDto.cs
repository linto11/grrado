namespace LoggingService.Application.DTOs;

public class RequestResponseLogDto
{
    public int Id { get; set; }
    public string RequestId { get; set; } = string.Empty;
    public string HttpMethod { get; set; } = string.Empty;
    public string Endpoint { get; set; } = string.Empty;
    public string? QueryString { get; set; }
    public string? RequestBody { get; set; }
    public int ResponseStatusCode { get; set; }
    public string? ResponseBody { get; set; }
    public long ResponseTimeMs { get; set; }
    public int? UserId { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
    public string? Metadata { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
