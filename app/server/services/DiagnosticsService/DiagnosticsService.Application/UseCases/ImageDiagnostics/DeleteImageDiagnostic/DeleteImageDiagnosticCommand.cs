using GRRADO.Shared.Application.Common;
using MediatR;

namespace DiagnosticsService.Application.UseCases.ImageDiagnostics.DeleteImageDiagnostic;

public class DeleteImageDiagnosticCommand : IRequest<Result>
{
    public int Id { get; set; }
    public DeleteImageDiagnosticCommand(int id) => Id = id;
}
