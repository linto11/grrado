using AutoMapper;
using ServiceHistoryService.Application.DTOs;
using ServiceHistoryService.Application.UseCases.ServiceHistories.CreateServiceHistory;
using ServiceHistoryService.Application.UseCases.ServiceHistories.UpdateServiceHistory;
using ServiceHistoryService.Domain.Entities;

namespace ServiceHistoryService.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ServiceHistory, ServiceHistoryDto>();
        CreateMap<CreateServiceHistoryCommand, ServiceHistory>();
        CreateMap<UpdateServiceHistoryCommand, ServiceHistory>();
    }
}
