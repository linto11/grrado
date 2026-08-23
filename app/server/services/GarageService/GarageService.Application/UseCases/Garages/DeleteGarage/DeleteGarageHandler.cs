using GarageService.Application.Abstractions;
using GRRADO.Shared.Abstractions.Caching;
using GRRADO.Shared.Abstractions.Messaging;
using GRRADO.Shared.Application.Common;
using GRRADO.Shared.Domain.Constants;
using GRRADO.Shared.Domain.Events;
using MediatR;

namespace GarageService.Application.UseCases.Garages.DeleteGarage;

public class DeleteGarageHandler : IRequestHandler<DeleteGarageCommand, Result>
{
    private readonly IGarageUnitOfWork _unitOfWork;
    private readonly IEventPublisher _eventPublisher;
    private readonly ICacheService _cache;

    public DeleteGarageHandler(IGarageUnitOfWork unitOfWork, IEventPublisher eventPublisher, ICacheService cache)
    {
        _unitOfWork = unitOfWork;
        _eventPublisher = eventPublisher;
        _cache = cache;
    }

    public async Task<Result> Handle(DeleteGarageCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _unitOfWork.Garages.DeleteAsync(request.Id);

        if (!deleted)
            return Result.Failure("Garage not found.");

        await _unitOfWork.SaveChangesAsync();

        await _cache.RemoveAsync($"garage:{request.Id}", cancellationToken);

        await _eventPublisher.PublishAsync(new GarageDeletedEvent
        {
            GarageId = request.Id,
            DeletedBy = AuditConstants.SYSTEM_ACTOR
        }, cancellationToken);

        return Result.Success();
    }
}
