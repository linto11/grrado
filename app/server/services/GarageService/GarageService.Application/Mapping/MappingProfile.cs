using AutoMapper;
using GarageService.Application.DTOs;
using GarageService.Domain.Entities;

namespace GarageService.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Garage, GarageDto>();
        CreateMap<CreateGarageRequest, Garage>();

        CreateMap<Service, ServiceDto>();
        CreateMap<CreateServiceRequest, Service>();
    }
}
