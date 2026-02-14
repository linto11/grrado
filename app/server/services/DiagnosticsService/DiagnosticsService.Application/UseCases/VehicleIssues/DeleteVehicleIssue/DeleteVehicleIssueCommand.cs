using GRRADO.Shared.Application.Common;
using MediatR;

namespace DiagnosticsService.Application.UseCases.VehicleIssues.DeleteVehicleIssue;

public class DeleteVehicleIssueCommand : IRequest<Result>
{
    public int Id { get; set; }
    public DeleteVehicleIssueCommand(int id) => Id = id;
}
