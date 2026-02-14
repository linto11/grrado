using GRRADO.Shared.Application.Common;
using UserService.Application.DTOs;
using MediatR;

namespace UserService.Application.UseCases.Users.GetUserById;

public class GetUserByIdQuery : IRequest<Result<UserDto>>
{
    public int Id { get; set; }
    public GetUserByIdQuery(int id) => Id = id;
}
