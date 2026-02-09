using Abstractions.DTOs.VehicleIssue;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.VehicleIssues.GetAllVehicleIssues;

public class GetAllVehicleIssuesHandler : IRequestHandler<GetAllVehicleIssuesRequest, Result<PaginatedResult<VehicleIssueDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllVehicleIssuesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<PaginatedResult<VehicleIssueDto>>> Handle(GetAllVehicleIssuesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var pagedResult = await _unitOfWork.VehicleIssues.GetPagedAsync(request.PageNumber, request.PageSize);
            var dtos = _mapper.Map<List<VehicleIssueDto>>(pagedResult.Items);
            var paginatedResult = new PaginatedResult<VehicleIssueDto>
            {
                Items = dtos,
                TotalCount = pagedResult.TotalCount,
                Skip = pagedResult.Skip,
                Take = pagedResult.Take
            };
            return Result<PaginatedResult<VehicleIssueDto>>.Success(paginatedResult);
        }
        catch (Exception ex)
        {
            return Result<PaginatedResult<VehicleIssueDto>>.Failure($"Failed to retrieve vehicleIssue list: {ex.Message}");
        }
    }
}
