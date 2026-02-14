using GRRADO.Shared.Application.Common;
using ServiceHistoryService.Application.Abstractions;
using MediatR;

namespace ServiceHistoryService.Application.UseCases.ServiceHistories.DeleteServiceHistory;

public class DeleteServiceHistoryHandler : IRequestHandler<DeleteServiceHistoryCommand, Result>
{
    private readonly IServiceHistoryUnitOfWork _unitOfWork;

    public DeleteServiceHistoryHandler(IServiceHistoryUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteServiceHistoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var deleted = await _unitOfWork.ServiceHistories.DeleteAsync(request.Id);
            if (!deleted)
                return Result.Failure("Service history not found");
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete service history: {ex.Message}");
        }
    }
}
