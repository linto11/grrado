using AutoMapper;
using GRRADO.Shared.Abstractions.Caching;
using GRRADO.Shared.Application.Common;
using VehicleService.Application.Abstractions;
using VehicleService.Application.DTOs;
using MediatR;

namespace VehicleService.Application.UseCases.Vehicles.GetVehicleById;

public class GetVehicleByIdHandler : IRequestHandler<GetVehicleByIdQuery, Result<VehicleDto>>
{
    private readonly IVehicleUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheService _cache;

    public GetVehicleByIdHandler(IVehicleUnitOfWork unitOfWork, IMapper mapper, ICacheService cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cache;
    }

    public async Task<Result<VehicleDto>> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var cacheKey = $"vehicle:{request.Id}";
            var cached = await _cache.GetAsync<VehicleDto>(cacheKey, cancellationToken);
            if (cached != null)
                return Result<VehicleDto>.Success(cached);

            var entity = await _unitOfWork.Vehicles.GetByIdAsync(request.Id);
            if (entity == null)
                return Result<VehicleDto>.Failure($"Vehicle with id {request.Id} not found");

            var dto = _mapper.Map<VehicleDto>(entity);
            await _cache.SetAsync(cacheKey, dto, cancellationToken: cancellationToken);
            return Result<VehicleDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<VehicleDto>.Failure($"Failed to get vehicle: {ex.Message}");
        }
    }
}
