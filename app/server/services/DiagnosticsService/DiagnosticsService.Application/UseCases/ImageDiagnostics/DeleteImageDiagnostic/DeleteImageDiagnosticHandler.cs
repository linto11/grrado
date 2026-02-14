using GRRADO.Shared.Application.Common;
using DiagnosticsService.Application.Abstractions;
using MediatR;

namespace DiagnosticsService.Application.UseCases.ImageDiagnostics.DeleteImageDiagnostic;

public class DeleteImageDiagnosticHandler : IRequestHandler<DeleteImageDiagnosticCommand, Result>
{
    private readonly IDiagnosticsUnitOfWork _unitOfWork;

    public DeleteImageDiagnosticHandler(IDiagnosticsUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteImageDiagnosticCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ImageDiagnostics.GetByIdAsync(request.Id);
            if (entity == null)
                return Result.Failure($"ImageDiagnostic with id {request.Id} not found");

            await _unitOfWork.ImageDiagnostics.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete image diagnostic: {ex.Message}");
        }
    }
}
