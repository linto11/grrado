using GRRADO.Shared.Abstractions.Caching;
using GRRADO.Shared.Abstractions.Messaging;
using GRRADO.Shared.Application.Common;
using GRRADO.Shared.Domain.Constants;
using GRRADO.Shared.Domain.Events;
using VehicleService.Application.Abstractions;
using MediatR;

namespace VehicleService.Application.UseCases.Vehicles.DeleteVehicle;

public class DeleteVehicleHandler : IRequestHandler<DeleteVehicleCommand, Result>
{
    private readonly IVehicleUnitOfWork _unitOfWork;
    private readonly IEventPublisher _eventPublisher;
    private readonly ICacheService _cache;

    public DeleteVehicleHandler(IVehicleUnitOfWork unitOfWork, IEventPublisher eventPublisher, ICacheService cache)
    {
        _unitOfWork = unitOfWork;
        _eventPublisher = eventPublisher;
        _cache = cache;
    }

    public async Task<Result> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.Vehicles.GetByIdAsync(request.Id);
            if (entity == null)
                return Result.Failure($"Vehicle with id {request.Id} not found");

            await _unitOfWork.Vehicles.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();

            await _cache.RemoveAsync($"vehicle:{request.Id}", cancellationToken);

            await _eventPublisher.PublishAsync(new VehicleDeletedEvent
            {
                VehicleId = request.Id,
                UserId = entity.UserId,
                DeletedBy = AuditConstants.SYSTEM_ACTOR
            }, cancellationToken);

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete vehicle: {ex.Message}");
        }
    }
}
