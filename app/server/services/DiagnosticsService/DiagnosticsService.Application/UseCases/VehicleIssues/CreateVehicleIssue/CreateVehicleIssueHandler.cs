using AutoMapper;
using GRRADO.Shared.Application.Common;
using DiagnosticsService.Application.Abstractions;
using DiagnosticsService.Application.DTOs;
using DiagnosticsService.Domain.Entities;
using MediatR;

namespace DiagnosticsService.Application.UseCases.VehicleIssues.CreateVehicleIssue;

public class CreateVehicleIssueHandler : IRequestHandler<CreateVehicleIssueCommand, Result<VehicleIssueDto>>
{
    private readonly IDiagnosticsUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateVehicleIssueHandler(IDiagnosticsUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<VehicleIssueDto>> Handle(CreateVehicleIssueCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<VehicleIssue>(request);
            await _unitOfWork.VehicleIssues.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<VehicleIssueDto>.Success(_mapper.Map<VehicleIssueDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<VehicleIssueDto>.Failure($"Failed to create vehicle issue: {ex.Message}");
        }
    }
}
