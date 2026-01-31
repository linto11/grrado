using Abstractions.DTOs.Garage;
using Abstractions.Persistence;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Core;

public interface IGarageService : IBaseService<Garage, GarageDto, CreateGarageRequest, UpdateGarageRequest>
{
}

public class GarageService : BaseService<Garage, GarageDto, CreateGarageRequest, UpdateGarageRequest>, IGarageService
{
    public GarageService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    protected override IRepository<Garage> GetRepository() => _unitOfWork.Garages;
}
