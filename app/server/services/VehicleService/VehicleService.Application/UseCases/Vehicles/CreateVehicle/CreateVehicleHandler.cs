using AutoMapper;
using GRRADO.Shared.Application.Common;
using VehicleService.Application.Abstractions;
using VehicleService.Application.DTOs;
using VehicleService.Domain.Entities;
using MediatR;

namespace VehicleService.Application.UseCases.Vehicles.CreateVehicle;

public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, Result<VehicleDto>>
{
    private readonly IVehicleUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateVehicleHandler(IVehicleUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<VehicleDto>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Vehicle>(request);
            await _unitOfWork.Vehicles.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<VehicleDto>.Success(_mapper.Map<VehicleDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<VehicleDto>.Failure($"Failed to create vehicle: {ex.Message}");
        }
    }
}
