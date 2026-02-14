using GRRADO.Shared.Application.Common;
using MediatR;
using DiagnosticsService.Application.DTOs;

namespace DiagnosticsService.Application.UseCases.VehicleIssues.CreateVehicleIssue;

public class CreateVehicleIssueCommand : IRequest<Result<VehicleIssueDto>>
{
    public string Symptom { get; set; } = string.Empty;
    public string AffectedSystem { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public bool DrivesSafe { get; set; }
    public string Description { get; set; } = string.Empty;
    public string PossibleCauses { get; set; } = string.Empty;
}
