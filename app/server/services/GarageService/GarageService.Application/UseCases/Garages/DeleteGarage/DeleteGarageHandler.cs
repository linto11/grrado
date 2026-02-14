using GarageService.Application.Abstractions;
using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Garages.DeleteGarage;

public class DeleteGarageHandler : IRequestHandler<DeleteGarageCommand, Result>
{
    private readonly IGarageUnitOfWork _unitOfWork;

    public DeleteGarageHandler(IGarageUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteGarageCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _unitOfWork.Garages.DeleteAsync(request.Id);

        if (!deleted)
            return Result.Failure("Garage not found.");

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
