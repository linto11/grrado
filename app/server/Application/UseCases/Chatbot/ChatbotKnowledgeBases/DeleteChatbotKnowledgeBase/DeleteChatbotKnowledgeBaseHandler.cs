using Abstractions.Persistence;
using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Chatbot.ChatbotKnowledgeBases.DeleteChatbotKnowledgeBase;

public class DeleteChatbotKnowledgeBaseHandler : IRequestHandler<DeleteChatbotKnowledgeBaseRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteChatbotKnowledgeBaseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteChatbotKnowledgeBaseRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ChatbotKnowledgeBases.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result.Failure($"ChatbotKnowledgeBase with ID {request.Id} not found");
            }
            await _unitOfWork.ChatbotKnowledgeBases.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Failed to delete chatbotKnowledgeBase: {ex.Message}");
        }
    }
}
