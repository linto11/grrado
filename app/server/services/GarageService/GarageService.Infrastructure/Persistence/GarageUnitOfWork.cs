using GRRADO.Shared.Abstractions.Persistence;
using GRRADO.Shared.Infrastructure.Persistence;
using Polly;
using GarageService.Application.Abstractions;
using GarageService.Domain.Entities;

namespace GarageService.Infrastructure.Persistence;

public class GarageUnitOfWork : BaseUnitOfWork, IGarageUnitOfWork
{
    private IRepository<Garage>? _garages;
    private IRepository<Service>? _services;

    public GarageUnitOfWork(GarageDbContext context, IAsyncPolicy databaseResiliencePolicy)
        : base(context, databaseResiliencePolicy) { }

    public IRepository<Garage> Garages =>
        _garages ??= new BaseRepository<Garage>(_context);

    public IRepository<Service> Services =>
        _services ??= new BaseRepository<Service>(_context);
}
