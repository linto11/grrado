namespace DiagnosticsService.Application.DTOs;

public class UpdateVehicleIssueRequest
{
    public string Symptom { get; set; } = string.Empty;
    public string AffectedSystem { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public bool DrivesSafe { get; set; }
    public string Description { get; set; } = string.Empty;
    public string PossibleCauses { get; set; } = string.Empty;
}
