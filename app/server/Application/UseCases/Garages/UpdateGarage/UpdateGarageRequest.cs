using Application.Common.Models;
using Abstractions.DTOs.Garage;
using MediatR;

namespace Application.UseCases.Garages.UpdateGarage;

public class UpdateGarageRequest : IRequest<Result<GarageDto>>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string GarageType { get; set; } = string.Empty;
    public bool EvSupported { get; set; }
    public double Rating { get; set; }
    public string OperatingHours { get; set; } = string.Empty;
}
