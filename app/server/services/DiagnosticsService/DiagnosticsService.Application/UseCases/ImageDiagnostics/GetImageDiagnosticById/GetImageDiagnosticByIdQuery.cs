using GRRADO.Shared.Application.Common;
using MediatR;
using DiagnosticsService.Application.DTOs;

namespace DiagnosticsService.Application.UseCases.ImageDiagnostics.GetImageDiagnosticById;

public class GetImageDiagnosticByIdQuery : IRequest<Result<ImageDiagnosticDto>>
{
    public int Id { get; set; }
    public GetImageDiagnosticByIdQuery(int id) => Id = id;
}
