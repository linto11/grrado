using Abstractions.DTOs.User;
using Abstractions.Persistence;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Core;

public interface IUserService : IBaseService<User, UserDto, CreateUserRequest, UpdateUserRequest>
{
}

public class UserService : BaseService<User, UserDto, CreateUserRequest, UpdateUserRequest>, IUserService
{
    public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    protected override IRepository<User> GetRepository() => _unitOfWork.Users;
}
