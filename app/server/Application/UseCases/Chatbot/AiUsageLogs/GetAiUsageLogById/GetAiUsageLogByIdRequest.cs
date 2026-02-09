using Application.Common.Models;
using Abstractions.DTOs.AiUsageLog;
using MediatR;

namespace Application.UseCases.Chatbot.AiUsageLogs.GetAiUsageLogById;

public class GetAiUsageLogByIdRequest : IRequest<Result<AiUsageLogDto>>
{
    public int Id { get; set; }

    public GetAiUsageLogByIdRequest(int id)
    {
        Id = id;
    }

    public GetAiUsageLogByIdRequest()
    {
    }
}
