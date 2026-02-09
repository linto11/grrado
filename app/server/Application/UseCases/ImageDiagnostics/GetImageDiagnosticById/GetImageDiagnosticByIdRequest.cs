using Application.Common.Models;
using Abstractions.DTOs.ImageDiagnostic;
using MediatR;

namespace Application.UseCases.ImageDiagnostics.GetImageDiagnosticById;

public class GetImageDiagnosticByIdRequest : IRequest<Result<ImageDiagnosticDto>>
{
    public int Id { get; set; }

    public GetImageDiagnosticByIdRequest(int id)
    {
        Id = id;
    }

    public GetImageDiagnosticByIdRequest()
    {
    }
}
