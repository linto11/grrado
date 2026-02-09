using Application.Common.Models;
using Abstractions.DTOs.Service;
using MediatR;

namespace Application.UseCases.Core.Services.GetServiceById;

public class GetServiceByIdRequest : IRequest<Result<ServiceDto>>
{
    public int Id { get; set; }

    public GetServiceByIdRequest(int id)
    {
        Id = id;
    }

    public GetServiceByIdRequest()
    {
    }
}
