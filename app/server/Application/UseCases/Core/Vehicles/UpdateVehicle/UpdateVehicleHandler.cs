using Abstractions.DTOs.Vehicle;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Core.Vehicles.UpdateVehicle;

public class UpdateVehicleHandler : IRequestHandler<UpdateVehicleRequest, Result<VehicleDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateVehicleHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<VehicleDto>> Handle(UpdateVehicleRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.Vehicles.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<VehicleDto>.Failure($"Vehicle with ID {request.Id} not found");
            }
            _mapper.Map(request, entity);
            await _unitOfWork.Vehicles.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<VehicleDto>(entity);
            return Result<VehicleDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<VehicleDto>.Failure($"Failed to update vehicle: {ex.Message}");
        }
    }
}
