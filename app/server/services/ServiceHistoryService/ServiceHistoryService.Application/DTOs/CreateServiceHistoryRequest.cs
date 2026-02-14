namespace ServiceHistoryService.Application.DTOs;

public class CreateServiceHistoryRequest
{
    public int VehicleId { get; set; }
    public int GarageId { get; set; }
    public int ServiceId { get; set; }
    public DateTime ServiceDate { get; set; }
    public double MileageKm { get; set; }
    public decimal CostAed { get; set; }
    public string Outcome { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public int? TechnicianId { get; set; }
}
