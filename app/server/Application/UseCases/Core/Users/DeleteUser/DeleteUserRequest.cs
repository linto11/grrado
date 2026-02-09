using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Core.Users.DeleteUser;

public class DeleteUserRequest : IRequest<Result>
{
    public int Id { get; set; }

    public DeleteUserRequest(int id)
    {
        Id = id;
    }

    public DeleteUserRequest()
    {
    }
}
