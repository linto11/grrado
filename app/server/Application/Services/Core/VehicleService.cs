using Abstractions.DTOs.Vehicle;
using Abstractions.Persistence;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Core;

public interface IVehicleService : IBaseService<Vehicle, VehicleDto, CreateVehicleRequest, UpdateVehicleRequest>
{
}

public class VehicleService : BaseService<Vehicle, VehicleDto, CreateVehicleRequest, UpdateVehicleRequest>, IVehicleService
{
    public VehicleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    protected override IRepository<Vehicle> GetRepository() => _unitOfWork.Vehicles;
}
