using Abstractions.Persistence;
using Application.Common.Models;
using MediatR;

namespace Application.UseCases.ChatbotMessages.DeleteChatbotMessage;

public class DeleteChatbotMessageHandler : IRequestHandler<DeleteChatbotMessageRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteChatbotMessageHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteChatbotMessageRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ChatbotMessages.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result.Failure($"ChatbotMessage with ID {request.Id} not found");
            }
            await _unitOfWork.ChatbotMessages.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete chatbotMessage: {ex.Message}");
        }
    }
}
