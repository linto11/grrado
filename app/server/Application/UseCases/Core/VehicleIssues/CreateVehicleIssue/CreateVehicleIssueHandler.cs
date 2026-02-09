using Abstractions.DTOs.VehicleIssue;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Core.VehicleIssues.CreateVehicleIssue;

public class CreateVehicleIssueHandler : IRequestHandler<CreateVehicleIssueRequest, Result<VehicleIssueDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateVehicleIssueHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<VehicleIssueDto>> Handle(CreateVehicleIssueRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<VehicleIssue>(request);
            await _unitOfWork.VehicleIssues.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<VehicleIssueDto>(entity);
            return Result<VehicleIssueDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<VehicleIssueDto>.Failure($"Failed to create vehicleIssue: {ex.Message}");
        }
    }
}
