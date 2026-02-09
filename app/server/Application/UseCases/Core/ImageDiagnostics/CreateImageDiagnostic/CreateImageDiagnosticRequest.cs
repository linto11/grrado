using Application.Common.Models;
using Abstractions.DTOs.ImageDiagnostic;
using MediatR;

namespace Application.UseCases.Core.ImageDiagnostics.CreateImageDiagnostic;

public class CreateImageDiagnosticRequest : IRequest<Result<ImageDiagnosticDto>>
{
    public int VehicleId { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    public string PredictedIssue { get; set; } = string.Empty;
    public double Confidence { get; set; }
    public string Status { get; set; } = string.Empty;
}
