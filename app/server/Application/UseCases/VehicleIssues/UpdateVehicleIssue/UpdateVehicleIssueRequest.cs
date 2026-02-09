using Application.Common.Models;
using Abstractions.DTOs.VehicleIssue;
using MediatR;

namespace Application.UseCases.VehicleIssues.UpdateVehicleIssue;

public class UpdateVehicleIssueRequest : IRequest<Result<VehicleIssueDto>>
{
    public int Id { get; set; }
    public string IssueType { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsResolved { get; set; }
    public DateTime? ResolvedDate { get; set; }
}
