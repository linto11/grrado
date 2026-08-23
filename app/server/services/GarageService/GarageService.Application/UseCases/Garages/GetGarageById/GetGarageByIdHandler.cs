using AutoMapper;
using GarageService.Application.Abstractions;
using GarageService.Application.DTOs;
using GRRADO.Shared.Abstractions.Caching;
using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Garages.GetGarageById;

public class GetGarageByIdHandler : IRequestHandler<GetGarageByIdQuery, Result<GarageDto>>
{
    private readonly IGarageUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheService _cache;

    public GetGarageByIdHandler(IGarageUnitOfWork unitOfWork, IMapper mapper, ICacheService cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cache;
    }

    public async Task<Result<GarageDto>> Handle(GetGarageByIdQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"garage:{request.Id}";
        var cached = await _cache.GetAsync<GarageDto>(cacheKey, cancellationToken);
        if (cached != null)
            return Result<GarageDto>.Success(cached);

        var entity = await _unitOfWork.Garages.GetByIdAsync(request.Id);

        if (entity is null)
            return Result<GarageDto>.Failure("Garage not found.");

        var dto = _mapper.Map<GarageDto>(entity);
        await _cache.SetAsync(cacheKey, dto, cancellationToken: cancellationToken);
        return Result<GarageDto>.Success(dto);
    }
}
