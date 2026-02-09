using Application.Common.Models;
using Abstractions.DTOs.ImageDiagnostic;
using MediatR;

namespace Application.UseCases.Core.ImageDiagnostics.UpdateImageDiagnostic;

public class UpdateImageDiagnosticRequest : IRequest<Result<ImageDiagnosticDto>>
{
    public int Id { get; set; }
    public string PredictedIssue { get; set; } = string.Empty;
    public double Confidence { get; set; }
    public string Status { get; set; } = string.Empty;
}
