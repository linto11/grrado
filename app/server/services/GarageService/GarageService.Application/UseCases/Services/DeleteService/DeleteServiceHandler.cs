using GarageService.Application.Abstractions;
using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Services.DeleteService;

public class DeleteServiceHandler : IRequestHandler<DeleteServiceCommand, Result>
{
    private readonly IGarageUnitOfWork _unitOfWork;

    public DeleteServiceHandler(IGarageUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _unitOfWork.Services.DeleteAsync(request.Id);

        if (!deleted)
            return Result.Failure("Service not found.");

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
