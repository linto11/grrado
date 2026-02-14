using GRRADO.Shared.Abstractions.Persistence;
using GarageService.Domain.Entities;

namespace GarageService.Application.Abstractions;

public interface IGarageUnitOfWork : IUnitOfWork
{
    IRepository<Garage> Garages { get; }
    IRepository<Service> Services { get; }
}
