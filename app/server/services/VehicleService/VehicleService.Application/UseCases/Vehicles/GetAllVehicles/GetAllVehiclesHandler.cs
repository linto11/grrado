using AutoMapper;
using GRRADO.Shared.Application.Common;
using Microsoft.EntityFrameworkCore;
using VehicleService.Application.Abstractions;
using VehicleService.Application.DTOs;
using MediatR;

namespace VehicleService.Application.UseCases.Vehicles.GetAllVehicles;

public class GetAllVehiclesHandler : IRequestHandler<GetAllVehiclesQuery, Result<List<VehicleDto>>>
{
    private readonly IVehicleUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllVehiclesHandler(IVehicleUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<VehicleDto>>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await _unitOfWork.Vehicles.GetAll()
                .Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
            var dtos = _mapper.Map<List<VehicleDto>>(entities);
            return Result<List<VehicleDto>>.Success(dtos);
        }
        catch (Exception ex)
        {
            return Result<List<VehicleDto>>.Failure($"Failed to get vehicles: {ex.Message}");
        }
    }
}
