using Application.Common.Models;
using Abstractions.DTOs.ImageDiagnostic;
using Abstractions.Persistence;
using MediatR;

namespace Application.UseCases.Core.ImageDiagnostics.GetAllImageDiagnostics;

public class GetAllImageDiagnosticsRequest : IRequest<Result<PaginatedResult<ImageDiagnosticDto>>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
