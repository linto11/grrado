using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Services.DeleteService;

public class DeleteServiceRequest : IRequest<Result>
{
    public int Id { get; set; }

    public DeleteServiceRequest(int id)
    {
        Id = id;
    }

    public DeleteServiceRequest()
    {
    }
}
