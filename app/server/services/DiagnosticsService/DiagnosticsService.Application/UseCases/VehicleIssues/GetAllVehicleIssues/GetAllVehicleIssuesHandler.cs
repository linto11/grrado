using AutoMapper;
using GRRADO.Shared.Application.Common;
using DiagnosticsService.Application.Abstractions;
using DiagnosticsService.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiagnosticsService.Application.UseCases.VehicleIssues.GetAllVehicleIssues;

public class GetAllVehicleIssuesHandler : IRequestHandler<GetAllVehicleIssuesQuery, Result<List<VehicleIssueDto>>>
{
    private readonly IDiagnosticsUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllVehicleIssuesHandler(IDiagnosticsUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<VehicleIssueDto>>> Handle(GetAllVehicleIssuesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await _unitOfWork.VehicleIssues.GetAll()
                .Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
            var dtos = _mapper.Map<List<VehicleIssueDto>>(entities);
            return Result<List<VehicleIssueDto>>.Success(dtos);
        }
        catch (Exception ex)
        {
            return Result<List<VehicleIssueDto>>.Failure($"Failed to get vehicle issues: {ex.Message}");
        }
    }
}
