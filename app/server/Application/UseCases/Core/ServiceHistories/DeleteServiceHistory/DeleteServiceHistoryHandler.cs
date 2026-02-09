using Abstractions.Persistence;
using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Core.ServiceHistories.DeleteServiceHistory;

public class DeleteServiceHistoryHandler : IRequestHandler<DeleteServiceHistoryRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteServiceHistoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteServiceHistoryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ServiceHistories.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result.Failure($"ServiceHistory with ID {request.Id} not found");
            }
            await _unitOfWork.ServiceHistories.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete serviceHistory: {ex.Message}");
        }
    }
}
