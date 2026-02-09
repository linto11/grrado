using Abstractions.DTOs.Vehicle;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Vehicles.CreateVehicle;

public class CreateVehicleHandler : IRequestHandler<CreateVehicleRequest, Result<VehicleDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateVehicleHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<VehicleDto>> Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Vehicle>(request);
            await _unitOfWork.Vehicles.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<VehicleDto>(entity);
            return Result<VehicleDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<VehicleDto>.Failure($"Failed to create vehicle: {ex.Message}");
        }
    }
}
