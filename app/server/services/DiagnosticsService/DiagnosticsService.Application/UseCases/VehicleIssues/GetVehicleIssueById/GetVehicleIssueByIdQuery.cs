using GRRADO.Shared.Application.Common;
using MediatR;
using DiagnosticsService.Application.DTOs;

namespace DiagnosticsService.Application.UseCases.VehicleIssues.GetVehicleIssueById;

public class GetVehicleIssueByIdQuery : IRequest<Result<VehicleIssueDto>>
{
    public int Id { get; set; }
    public GetVehicleIssueByIdQuery(int id) => Id = id;
}
