using GRRADO.Shared.Abstractions.Persistence;
using UserService.Domain.Entities;

namespace UserService.Application.Abstractions;

public interface IUserUnitOfWork : IUnitOfWork
{
    IRepository<User> Users { get; }
}
