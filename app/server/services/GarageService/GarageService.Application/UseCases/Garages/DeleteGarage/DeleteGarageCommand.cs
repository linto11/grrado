using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Garages.DeleteGarage;

public class DeleteGarageCommand : IRequest<Result>
{
    public int Id { get; set; }

    public DeleteGarageCommand(int id) => Id = id;
}
