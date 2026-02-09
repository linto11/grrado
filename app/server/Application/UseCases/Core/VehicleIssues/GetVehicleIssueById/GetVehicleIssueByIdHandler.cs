using Abstractions.DTOs.VehicleIssue;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Core.VehicleIssues.GetVehicleIssueById;

public class GetVehicleIssueByIdHandler : IRequestHandler<GetVehicleIssueByIdRequest, Result<VehicleIssueDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetVehicleIssueByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<VehicleIssueDto>> Handle(GetVehicleIssueByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.VehicleIssues.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<VehicleIssueDto>.Failure($"VehicleIssue with ID {request.Id} not found");
            }
            var dto = _mapper.Map<VehicleIssueDto>(entity);
            return Result<VehicleIssueDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<VehicleIssueDto>.Failure($"Failed to retrieve vehicleIssue: {ex.Message}");
        }
    }
}
