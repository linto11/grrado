using Abstractions.DTOs.VehicleIssue;
using Abstractions.Persistence;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Core;

public interface IVehicleIssueService : IBaseService<VehicleIssue, VehicleIssueDto, CreateVehicleIssueRequest, UpdateVehicleIssueRequest>
{
}

public class VehicleIssueService : BaseService<VehicleIssue, VehicleIssueDto, CreateVehicleIssueRequest, UpdateVehicleIssueRequest>, IVehicleIssueService
{
    public VehicleIssueService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    protected override IRepository<VehicleIssue> GetRepository() => _unitOfWork.VehicleIssues;
}
