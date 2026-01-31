using Abstractions.DTOs.ServiceHistory;
using Abstractions.Persistence;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Core;

public interface IServiceHistoryService : IBaseService<ServiceHistory, ServiceHistoryDto, CreateServiceHistoryRequest, UpdateServiceHistoryRequest>
{
}

public class ServiceHistoryService : BaseService<ServiceHistory, ServiceHistoryDto, CreateServiceHistoryRequest, UpdateServiceHistoryRequest>, IServiceHistoryService
{
    public ServiceHistoryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    protected override IRepository<ServiceHistory> GetRepository() => _unitOfWork.ServiceHistories;
}
