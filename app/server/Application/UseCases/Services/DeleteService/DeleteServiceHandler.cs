using Abstractions.Persistence;
using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Services.DeleteService;

public class DeleteServiceHandler : IRequestHandler<DeleteServiceRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteServiceHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteServiceRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.Services.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result.Failure($"Service with ID {request.Id} not found");
            }
            await _unitOfWork.Services.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete service: {ex.Message}");
        }
    }
}
