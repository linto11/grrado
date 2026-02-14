using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using MediatR;

namespace ChatbotService.Application.UseCases.ChatbotConversations.DeleteChatbotConversation;

public class DeleteChatbotConversationHandler : IRequestHandler<DeleteChatbotConversationCommand, Result>
{
    private readonly IChatbotUnitOfWork _unitOfWork;

    public DeleteChatbotConversationHandler(IChatbotUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeleteChatbotConversationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ChatbotConversations.GetByIdAsync(request.Id);
            if (entity == null)
                return Result.Failure($"ChatbotConversation with id {request.Id} not found");
            await _unitOfWork.ChatbotConversations.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete chatbot conversation: {ex.Message}");
        }
    }
}
