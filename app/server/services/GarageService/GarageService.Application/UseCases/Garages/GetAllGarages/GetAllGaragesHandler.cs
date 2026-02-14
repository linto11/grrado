using AutoMapper;
using GarageService.Application.Abstractions;
using GarageService.Application.DTOs;
using GRRADO.Shared.Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GarageService.Application.UseCases.Garages.GetAllGarages;

public class GetAllGaragesHandler : IRequestHandler<GetAllGaragesQuery, Result<List<GarageDto>>>
{
    private readonly IGarageUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllGaragesHandler(IGarageUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<GarageDto>>> Handle(GetAllGaragesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _unitOfWork.Garages.GetAll().ToListAsync(cancellationToken);
        var dtos = _mapper.Map<List<GarageDto>>(entities);
        return Result<List<GarageDto>>.Success(dtos);
    }
}
