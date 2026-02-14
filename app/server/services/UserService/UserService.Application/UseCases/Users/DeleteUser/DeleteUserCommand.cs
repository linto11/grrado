using GRRADO.Shared.Application.Common;
using MediatR;

namespace UserService.Application.UseCases.Users.DeleteUser;

public class DeleteUserCommand : IRequest<Result>
{
    public int Id { get; set; }
    public DeleteUserCommand(int id) => Id = id;
}
