using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Services.DeleteService;

public class DeleteServiceCommand : IRequest<Result>
{
    public int Id { get; set; }

    public DeleteServiceCommand(int id) => Id = id;
}
