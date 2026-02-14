using GRRADO.Shared.Application.Common;
using MediatR;
using DiagnosticsService.Application.DTOs;

namespace DiagnosticsService.Application.UseCases.VehicleIssues.GetAllVehicleIssues;

public class GetAllVehicleIssuesQuery : IRequest<Result<List<VehicleIssueDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
