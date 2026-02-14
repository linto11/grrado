using AutoMapper;
using GarageService.Application.Abstractions;
using GarageService.Application.DTOs;
using GRRADO.Shared.Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GarageService.Application.UseCases.Services.GetAllServices;

public class GetAllServicesHandler : IRequestHandler<GetAllServicesQuery, Result<List<ServiceDto>>>
{
    private readonly IGarageUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllServicesHandler(IGarageUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<ServiceDto>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _unitOfWork.Services.GetAll().ToListAsync(cancellationToken);
        var dtos = _mapper.Map<List<ServiceDto>>(entities);
        return Result<List<ServiceDto>>.Success(dtos);
    }
}
