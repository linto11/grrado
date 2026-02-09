using Abstractions.Persistence;
using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Chatbot.ChatbotConversations.DeleteChatbotConversation;

public class DeleteChatbotConversationHandler : IRequestHandler<DeleteChatbotConversationRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteChatbotConversationHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteChatbotConversationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ChatbotConversations.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result.Failure($"ChatbotConversation with ID {request.Id} not found");
            }
            await _unitOfWork.ChatbotConversations.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete chatbotConversation: {ex.Message}");
        }
    }
}
