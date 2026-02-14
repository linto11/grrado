using AutoMapper;
using GRRADO.Shared.Application.Common;
using DiagnosticsService.Application.Abstractions;
using DiagnosticsService.Application.DTOs;
using DiagnosticsService.Domain.Entities;
using MediatR;

namespace DiagnosticsService.Application.UseCases.VehicleIssues.UpdateVehicleIssue;

public class UpdateVehicleIssueHandler : IRequestHandler<UpdateVehicleIssueCommand, Result<VehicleIssueDto>>
{
    private readonly IDiagnosticsUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateVehicleIssueHandler(IDiagnosticsUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<VehicleIssueDto>> Handle(UpdateVehicleIssueCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.VehicleIssues.GetByIdAsync(request.Id);
            if (entity == null)
                return Result<VehicleIssueDto>.Failure($"VehicleIssue with id {request.Id} not found");

            entity.Symptom = request.Symptom;
            entity.AffectedSystem = request.AffectedSystem;
            entity.Severity = request.Severity;
            entity.DrivesSafe = request.DrivesSafe;
            entity.Description = request.Description;
            entity.PossibleCauses = request.PossibleCauses;
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.VehicleIssues.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<VehicleIssueDto>.Success(_mapper.Map<VehicleIssueDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<VehicleIssueDto>.Failure($"Failed to update vehicle issue: {ex.Message}");
        }
    }
}
