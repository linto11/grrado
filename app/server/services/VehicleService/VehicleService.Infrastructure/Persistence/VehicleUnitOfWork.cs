using GRRADO.Shared.Abstractions.Persistence;
using GRRADO.Shared.Infrastructure.Persistence;
using Polly;
using VehicleService.Application.Abstractions;
using VehicleService.Domain.Entities;

namespace VehicleService.Infrastructure.Persistence;

public class VehicleUnitOfWork : BaseUnitOfWork, IVehicleUnitOfWork
{
    private IRepository<Vehicle>? _vehicles;

    public VehicleUnitOfWork(VehicleDbContext context, IAsyncPolicy databaseResiliencePolicy)
        : base(context, databaseResiliencePolicy) { }

    public IRepository<Vehicle> Vehicles =>
        _vehicles ??= new BaseRepository<Vehicle>(_context);
}
