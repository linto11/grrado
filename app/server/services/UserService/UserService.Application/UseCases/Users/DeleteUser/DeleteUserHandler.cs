using GRRADO.Shared.Application.Common;
using UserService.Application.Abstractions;
using MediatR;

namespace UserService.Application.UseCases.Users.DeleteUser;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result>
{
    private readonly IUserUnitOfWork _unitOfWork;

    public DeleteUserHandler(IUserUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var deleted = await _unitOfWork.Users.DeleteAsync(request.Id);
            if (!deleted)
                return Result.Failure("User not found");
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete user: {ex.Message}");
        }
    }
}
