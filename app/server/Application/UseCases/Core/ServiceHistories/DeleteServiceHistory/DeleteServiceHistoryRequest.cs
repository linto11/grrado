using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Core.ServiceHistories.DeleteServiceHistory;

public class DeleteServiceHistoryRequest : IRequest<Result>
{
    public int Id { get; set; }

    public DeleteServiceHistoryRequest(int id)
    {
        Id = id;
    }

    public DeleteServiceHistoryRequest()
    {
    }
}
