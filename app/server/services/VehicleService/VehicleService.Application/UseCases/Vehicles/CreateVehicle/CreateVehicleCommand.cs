using GRRADO.Shared.Application.Common;
using MediatR;
using VehicleService.Application.DTOs;

namespace VehicleService.Application.UseCases.Vehicles.CreateVehicle;

public class CreateVehicleCommand : IRequest<Result<VehicleDto>>
{
    public int UserId { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string VehicleType { get; set; } = string.Empty;
    public string FuelType { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public double MileageKm { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}
