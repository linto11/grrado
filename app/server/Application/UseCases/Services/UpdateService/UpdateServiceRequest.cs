using Application.Common.Models;
using Abstractions.DTOs.Service;
using MediatR;

namespace Application.UseCases.Services.UpdateService;

public class UpdateServiceRequest : IRequest<Result<ServiceDto>>
{
    public int Id { get; set; }
    public string ServiceName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int DurationMinutes { get; set; }
    public string Description { get; set; } = string.Empty;
}
