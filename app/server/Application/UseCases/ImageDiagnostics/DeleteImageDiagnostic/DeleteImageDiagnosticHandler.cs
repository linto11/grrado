using Abstractions.Persistence;
using Application.Common.Models;
using MediatR;

namespace Application.UseCases.ImageDiagnostics.DeleteImageDiagnostic;

public class DeleteImageDiagnosticHandler : IRequestHandler<DeleteImageDiagnosticRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteImageDiagnosticHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteImageDiagnosticRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ImageDiagnostics.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result.Failure($"ImageDiagnostic with ID {request.Id} not found");
            }
            await _unitOfWork.ImageDiagnostics.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete imageDiagnostic: {ex.Message}");
        }
    }
}
