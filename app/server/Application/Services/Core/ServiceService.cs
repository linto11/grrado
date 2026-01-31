using Abstractions.DTOs.Service;
using Abstractions.Persistence;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Core;

public interface IServiceService : IBaseService<Service, ServiceDto, CreateServiceRequest, UpdateServiceRequest>
{
}

public class ServiceService : BaseService<Service, ServiceDto, CreateServiceRequest, UpdateServiceRequest>, IServiceService
{
    public ServiceService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    protected override IRepository<Service> GetRepository() => _unitOfWork.Services;
}
