using Application.Common.Models;
using Abstractions.DTOs.VehicleIssue;
using MediatR;

namespace Application.UseCases.Core.VehicleIssues.GetVehicleIssueById;

public class GetVehicleIssueByIdRequest : IRequest<Result<VehicleIssueDto>>
{
    public int Id { get; set; }

    public GetVehicleIssueByIdRequest(int id)
    {
        Id = id;
    }

    public GetVehicleIssueByIdRequest()
    {
    }
}
