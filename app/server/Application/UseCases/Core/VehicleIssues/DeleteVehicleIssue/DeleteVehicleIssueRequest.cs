using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Core.VehicleIssues.DeleteVehicleIssue;

public class DeleteVehicleIssueRequest : IRequest<Result>
{
    public int Id { get; set; }

    public DeleteVehicleIssueRequest(int id)
    {
        Id = id;
    }

    public DeleteVehicleIssueRequest()
    {
    }
}
