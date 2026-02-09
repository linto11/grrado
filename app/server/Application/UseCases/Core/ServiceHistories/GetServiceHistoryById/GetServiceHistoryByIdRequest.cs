using Application.Common.Models;
using Abstractions.DTOs.ServiceHistory;
using MediatR;

namespace Application.UseCases.Core.ServiceHistories.GetServiceHistoryById;

public class GetServiceHistoryByIdRequest : IRequest<Result<ServiceHistoryDto>>
{
    public int Id { get; set; }

    public GetServiceHistoryByIdRequest(int id)
    {
        Id = id;
    }

    public GetServiceHistoryByIdRequest()
    {
    }
}
