using Application.Common.Models;
using MediatR;

namespace Application.UseCases.AiUsageLogs.DeleteAiUsageLog;

public class DeleteAiUsageLogRequest : IRequest<Result>
{
    public int Id { get; set; }

    public DeleteAiUsageLogRequest(int id)
    {
        Id = id;
    }

    public DeleteAiUsageLogRequest()
    {
    }
}
