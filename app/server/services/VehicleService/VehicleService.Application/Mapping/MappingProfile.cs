using AutoMapper;
using VehicleService.Application.DTOs;
using VehicleService.Application.UseCases.Vehicles.CreateVehicle;
using VehicleService.Application.UseCases.Vehicles.UpdateVehicle;
using VehicleService.Domain.Entities;

namespace VehicleService.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Vehicle, VehicleDto>();
        CreateMap<CreateVehicleCommand, Vehicle>();
        CreateMap<UpdateVehicleCommand, Vehicle>();
    }
}
