using Application.Common.Models;
using Abstractions.DTOs.VehicleIssue;
using Abstractions.Persistence;
using MediatR;

namespace Application.UseCases.Core.VehicleIssues.GetAllVehicleIssues;

public class GetAllVehicleIssuesRequest : IRequest<Result<PaginatedResult<VehicleIssueDto>>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
