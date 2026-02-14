using GRRADO.Shared.Application.Common;
using MediatR;
using DiagnosticsService.Application.DTOs;

namespace DiagnosticsService.Application.UseCases.ImageDiagnostics.GetAllImageDiagnostics;

public class GetAllImageDiagnosticsQuery : IRequest<Result<List<ImageDiagnosticDto>>>
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
}
