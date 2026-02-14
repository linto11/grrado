using GRRADO.Shared.Application.Common;
using UserService.Application.DTOs;
using MediatR;

namespace UserService.Application.UseCases.Users.GetAllUsers;

public class GetAllUsersQuery : IRequest<Result<List<UserDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
