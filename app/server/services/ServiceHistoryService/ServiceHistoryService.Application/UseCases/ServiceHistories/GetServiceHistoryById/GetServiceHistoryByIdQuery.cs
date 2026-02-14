using GRRADO.Shared.Application.Common;
using MediatR;
using ServiceHistoryService.Application.DTOs;

namespace ServiceHistoryService.Application.UseCases.ServiceHistories.GetServiceHistoryById;

public class GetServiceHistoryByIdQuery : IRequest<Result<ServiceHistoryDto>>
{
    public int Id { get; set; }
    public GetServiceHistoryByIdQuery(int id) => Id = id;
}
