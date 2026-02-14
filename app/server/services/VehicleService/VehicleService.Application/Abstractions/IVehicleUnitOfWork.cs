using GRRADO.Shared.Abstractions.Persistence;
using VehicleService.Domain.Entities;

namespace VehicleService.Application.Abstractions;

public interface IVehicleUnitOfWork : IUnitOfWork
{
    IRepository<Vehicle> Vehicles { get; }
}
