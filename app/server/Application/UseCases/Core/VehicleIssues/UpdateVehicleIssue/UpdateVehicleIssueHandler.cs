using Abstractions.DTOs.VehicleIssue;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Core.VehicleIssues.UpdateVehicleIssue;

public class UpdateVehicleIssueHandler : IRequestHandler<UpdateVehicleIssueRequest, Result<VehicleIssueDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateVehicleIssueHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<VehicleIssueDto>> Handle(UpdateVehicleIssueRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.VehicleIssues.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<VehicleIssueDto>.Failure($"VehicleIssue with ID {request.Id} not found");
            }
            _mapper.Map(request, entity);
            await _unitOfWork.VehicleIssues.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<VehicleIssueDto>(entity);
            return Result<VehicleIssueDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<VehicleIssueDto>.Failure($"Failed to update vehicleIssue: {ex.Message}");
        }
    }
}
