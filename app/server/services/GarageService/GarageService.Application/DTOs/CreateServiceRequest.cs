namespace GarageService.Application.DTOs;

public class CreateServiceRequest
{
    public int GarageId { get; set; }
    public string ServiceName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal AvgCostAed { get; set; }
    public string SkillLevel { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int EstimatedDurationMinutes { get; set; }
}
