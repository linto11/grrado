using Application.Common.Models;
using Abstractions.DTOs.Service;
using MediatR;

namespace Application.UseCases.Core.Services.CreateService;

public class CreateServiceRequest : IRequest<Result<ServiceDto>>
{
    public int GarageId { get; set; }
    public string ServiceName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int DurationMinutes { get; set; }
    public string Description { get; set; } = string.Empty;
}
