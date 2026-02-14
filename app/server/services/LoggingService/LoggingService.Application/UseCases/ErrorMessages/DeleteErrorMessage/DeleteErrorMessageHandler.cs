using GRRADO.Shared.Application.Common;
using LoggingService.Application.Abstractions;
using MediatR;

namespace LoggingService.Application.UseCases.ErrorMessages.DeleteErrorMessage;

public class DeleteErrorMessageHandler : IRequestHandler<DeleteErrorMessageCommand, Result>
{
    private readonly ILoggingUnitOfWork _unitOfWork;
    public DeleteErrorMessageHandler(ILoggingUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    public async Task<Result> Handle(DeleteErrorMessageCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var deleted = await _unitOfWork.ErrorMessages.DeleteAsync(request.Id);
            if (!deleted) return Result.Failure("ErrorMessage not found");

            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex) { return Result.Failure($"Failed to delete error message: {ex.Message}"); }
    }
}
