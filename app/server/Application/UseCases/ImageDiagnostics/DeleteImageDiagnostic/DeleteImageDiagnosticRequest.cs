using Application.Common.Models;
using MediatR;

namespace Application.UseCases.ImageDiagnostics.DeleteImageDiagnostic;

public class DeleteImageDiagnosticRequest : IRequest<Result>
{
    public int Id { get; set; }

    public DeleteImageDiagnosticRequest(int id)
    {
        Id = id;
    }

    public DeleteImageDiagnosticRequest()
    {
    }
}
