using AutoMapper;
using GRRADO.Shared.Application.Common;
using VehicleService.Application.Abstractions;
using VehicleService.Application.DTOs;
using MediatR;

namespace VehicleService.Application.UseCases.Vehicles.GetVehicleById;

public class GetVehicleByIdHandler : IRequestHandler<GetVehicleByIdQuery, Result<VehicleDto>>
{
    private readonly IVehicleUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetVehicleByIdHandler(IVehicleUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<VehicleDto>> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.Vehicles.GetByIdAsync(request.Id);
            if (entity == null)
                return Result<VehicleDto>.Failure($"Vehicle with id {request.Id} not found");
            return Result<VehicleDto>.Success(_mapper.Map<VehicleDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<VehicleDto>.Failure($"Failed to get vehicle: {ex.Message}");
        }
    }
}
