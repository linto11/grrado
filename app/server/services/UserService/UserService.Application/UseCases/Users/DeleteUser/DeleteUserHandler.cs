using GRRADO.Shared.Abstractions.Caching;
using GRRADO.Shared.Abstractions.Messaging;
using GRRADO.Shared.Application.Common;
using GRRADO.Shared.Domain.Constants;
using GRRADO.Shared.Domain.Events;
using UserService.Application.Abstractions;
using MediatR;

namespace UserService.Application.UseCases.Users.DeleteUser;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result>
{
    private readonly IUserUnitOfWork _unitOfWork;
    private readonly IEventPublisher _eventPublisher;
    private readonly ICacheService _cache;

    public DeleteUserHandler(IUserUnitOfWork unitOfWork, IEventPublisher eventPublisher, ICacheService cache)
    {
        _unitOfWork = unitOfWork;
        _eventPublisher = eventPublisher;
        _cache = cache;
    }

    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var deleted = await _unitOfWork.Users.DeleteAsync(request.Id);
            if (!deleted)
                return Result.Failure("User not found");

            await _cache.RemoveAsync($"user:{request.Id}", cancellationToken);

            await _eventPublisher.PublishAsync(new UserDeletedEvent
            {
                UserId = request.Id,
                DeletedBy = AuditConstants.SYSTEM_ACTOR
            }, cancellationToken);

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete user: {ex.Message}");
        }
    }
}
