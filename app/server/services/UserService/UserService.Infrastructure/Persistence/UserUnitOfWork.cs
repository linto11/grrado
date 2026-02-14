using GRRADO.Shared.Abstractions.Persistence;
using GRRADO.Shared.Infrastructure.Persistence;
using Polly;
using UserService.Application.Abstractions;
using UserService.Domain.Entities;

namespace UserService.Infrastructure.Persistence;

public class UserUnitOfWork : BaseUnitOfWork, IUserUnitOfWork
{
    private IRepository<User>? _users;

    public UserUnitOfWork(UserDbContext context, IAsyncPolicy databaseResiliencePolicy)
        : base(context, databaseResiliencePolicy) { }

    public IRepository<User> Users =>
        _users ??= new BaseRepository<User>(_context);
}
