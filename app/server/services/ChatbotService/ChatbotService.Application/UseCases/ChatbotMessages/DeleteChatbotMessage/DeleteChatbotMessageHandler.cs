using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using MediatR;

namespace ChatbotService.Application.UseCases.ChatbotMessages.DeleteChatbotMessage;

public class DeleteChatbotMessageHandler : IRequestHandler<DeleteChatbotMessageCommand, Result>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    public DeleteChatbotMessageHandler(IChatbotUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeleteChatbotMessageCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ChatbotMessages.GetByIdAsync(request.Id);
            if (entity == null) return Result.Failure($"ChatbotMessage with id {request.Id} not found");
            await _unitOfWork.ChatbotMessages.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete chatbot message: {ex.Message}");
        }
    }
}
