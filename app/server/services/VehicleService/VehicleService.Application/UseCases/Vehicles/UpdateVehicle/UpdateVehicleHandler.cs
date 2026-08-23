using AutoMapper;
using GRRADO.Shared.Abstractions.Caching;
using GRRADO.Shared.Application.Common;
using VehicleService.Application.Abstractions;
using VehicleService.Application.DTOs;
using VehicleService.Domain.Entities;
using MediatR;

namespace VehicleService.Application.UseCases.Vehicles.UpdateVehicle;

public class UpdateVehicleHandler : IRequestHandler<UpdateVehicleCommand, Result<VehicleDto>>
{
    private readonly IVehicleUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheService _cache;

    public UpdateVehicleHandler(IVehicleUnitOfWork unitOfWork, IMapper mapper, ICacheService cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cache;
    }

    public async Task<Result<VehicleDto>> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.Vehicles.GetByIdAsync(request.Id);
            if (entity == null)
                return Result<VehicleDto>.Failure($"Vehicle with id {request.Id} not found");

            entity.UserId = request.UserId;
            entity.Brand = request.Brand;
            entity.Model = request.Model;
            entity.Year = request.Year;
            entity.VehicleType = request.VehicleType;
            entity.FuelType = request.FuelType;
            entity.Color = request.Color;
            entity.MileageKm = request.MileageKm;
            entity.LicensePlate = request.LicensePlate;
            entity.City = request.City;
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.Vehicles.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            await _cache.RemoveAsync($"vehicle:{request.Id}", cancellationToken);

            return Result<VehicleDto>.Success(_mapper.Map<VehicleDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<VehicleDto>.Failure($"Failed to update vehicle: {ex.Message}");
        }
    }
}
