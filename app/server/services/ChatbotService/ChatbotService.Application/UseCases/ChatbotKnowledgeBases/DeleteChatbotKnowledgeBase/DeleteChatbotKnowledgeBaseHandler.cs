using GRRADO.Shared.Application.Common;
using ChatbotService.Application.Abstractions;
using MediatR;

namespace ChatbotService.Application.UseCases.ChatbotKnowledgeBases.DeleteChatbotKnowledgeBase;

public class DeleteChatbotKnowledgeBaseHandler : IRequestHandler<DeleteChatbotKnowledgeBaseCommand, Result>
{
    private readonly IChatbotUnitOfWork _unitOfWork;
    public DeleteChatbotKnowledgeBaseHandler(IChatbotUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    public async Task<Result> Handle(DeleteChatbotKnowledgeBaseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var deleted = await _unitOfWork.ChatbotKnowledgeBases.DeleteAsync(request.Id);
            if (!deleted) return Result.Failure("ChatbotKnowledgeBase not found");
            return Result.Success();
        }
        catch (Exception ex) { return Result.Failure($"Failed to delete knowledge base entry: {ex.Message}"); }
    }
}
