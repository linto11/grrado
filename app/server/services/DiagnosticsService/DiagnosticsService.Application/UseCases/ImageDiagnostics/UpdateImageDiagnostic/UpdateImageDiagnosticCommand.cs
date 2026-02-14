using GRRADO.Shared.Application.Common;
using MediatR;
using DiagnosticsService.Application.DTOs;

namespace DiagnosticsService.Application.UseCases.ImageDiagnostics.UpdateImageDiagnostic;

public class UpdateImageDiagnosticCommand : IRequest<Result<ImageDiagnosticDto>>
{
    public int Id { get; set; }
    public string VisualFeature { get; set; } = string.Empty;
    public double Confidence { get; set; }
    public string LikelyIssue { get; set; } = string.Empty;
    public string Urgency { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string ImageType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
