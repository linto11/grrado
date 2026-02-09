using Abstractions.DTOs.Vehicle;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Vehicles.GetVehicleById;

public class GetVehicleByIdHandler : IRequestHandler<GetVehicleByIdRequest, Result<VehicleDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetVehicleByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<VehicleDto>> Handle(GetVehicleByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.Vehicles.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<VehicleDto>.Failure($"Vehicle with ID {request.Id} not found");
            }
            var dto = _mapper.Map<VehicleDto>(entity);
            return Result<VehicleDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<VehicleDto>.Failure($"Failed to retrieve vehicle: {ex.Message}");
        }
    }
}
