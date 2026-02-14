using AutoMapper;
using GRRADO.Shared.Application.Common;
using DiagnosticsService.Application.Abstractions;
using DiagnosticsService.Application.DTOs;
using MediatR;

namespace DiagnosticsService.Application.UseCases.VehicleIssues.GetVehicleIssueById;

public class GetVehicleIssueByIdHandler : IRequestHandler<GetVehicleIssueByIdQuery, Result<VehicleIssueDto>>
{
    private readonly IDiagnosticsUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetVehicleIssueByIdHandler(IDiagnosticsUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<VehicleIssueDto>> Handle(GetVehicleIssueByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.VehicleIssues.GetByIdAsync(request.Id);
            if (entity == null)
                return Result<VehicleIssueDto>.Failure($"VehicleIssue with id {request.Id} not found");
            return Result<VehicleIssueDto>.Success(_mapper.Map<VehicleIssueDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<VehicleIssueDto>.Failure($"Failed to get vehicle issue: {ex.Message}");
        }
    }
}
