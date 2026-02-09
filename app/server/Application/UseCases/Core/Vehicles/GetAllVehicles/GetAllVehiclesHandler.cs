using Abstractions.DTOs.Vehicle;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Core.Vehicles.GetAllVehicles;

public class GetAllVehiclesHandler : IRequestHandler<GetAllVehiclesRequest, Result<PaginatedResult<VehicleDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllVehiclesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<PaginatedResult<VehicleDto>>> Handle(GetAllVehiclesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var pagedResult = await _unitOfWork.Vehicles.GetPagedAsync(request.PageNumber, request.PageSize);
            var dtos = _mapper.Map<List<VehicleDto>>(pagedResult.Items);
            var paginatedResult = new PaginatedResult<VehicleDto>
            {
                Items = dtos,
                TotalCount = pagedResult.TotalCount,
                Skip = pagedResult.Skip,
                Take = pagedResult.Take
            };
            return Result<PaginatedResult<VehicleDto>>.Success(paginatedResult);
        }
        catch (Exception ex)
        {
            return Result<PaginatedResult<VehicleDto>>.Failure($"Failed to retrieve vehicle list: {ex.Message}");
        }
    }
}
