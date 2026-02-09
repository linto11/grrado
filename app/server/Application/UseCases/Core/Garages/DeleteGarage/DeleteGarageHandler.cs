using Abstractions.Persistence;
using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Core.Garages.DeleteGarage;

public class DeleteGarageHandler : IRequestHandler<DeleteGarageRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGarageHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteGarageRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.Garages.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result.Failure($"Garage with ID {request.Id} not found");
            }
            await _unitOfWork.Garages.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete garage: {ex.Message}");
        }
    }
}
