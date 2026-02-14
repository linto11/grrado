using GRRADO.Shared.Application.Common;
using MediatR;

namespace ServiceHistoryService.Application.UseCases.ServiceHistories.DeleteServiceHistory;

public class DeleteServiceHistoryCommand : IRequest<Result>
{
    public int Id { get; set; }
    public DeleteServiceHistoryCommand(int id) => Id = id;
}
