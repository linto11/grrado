using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Garages.DeleteGarage;

public class DeleteGarageRequest : IRequest<Result>
{
    public int Id { get; set; }

    public DeleteGarageRequest(int id)
    {
        Id = id;
    }

    public DeleteGarageRequest()
    {
    }
}
