using GarageService.Application.Abstractions;
using GRRADO.Shared.Abstractions.Messaging;
using GRRADO.Shared.Application.Common;
using GRRADO.Shared.Domain.Constants;
using GRRADO.Shared.Domain.Events;
using MediatR;

namespace GarageService.Application.UseCases.Services.DeleteService;

public class DeleteServiceHandler : IRequestHandler<DeleteServiceCommand, Result>
{
    private readonly IGarageUnitOfWork _unitOfWork;
    private readonly IEventPublisher _eventPublisher;

    public DeleteServiceHandler(IGarageUnitOfWork unitOfWork, IEventPublisher eventPublisher)
    {
        _unitOfWork = unitOfWork;
        _eventPublisher = eventPublisher;
    }

    public async Task<Result> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Services.GetByIdAsync(request.Id);
        if (entity == null)
            return Result.Failure("Service not found.");

        await _unitOfWork.Services.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();

        await _eventPublisher.PublishAsync(new ServiceDeletedEvent
        {
            ServiceId = request.Id,
            GarageId = entity.GarageId,
            DeletedBy = AuditConstants.SYSTEM_ACTOR
        }, cancellationToken);

        return Result.Success();
    }
}
