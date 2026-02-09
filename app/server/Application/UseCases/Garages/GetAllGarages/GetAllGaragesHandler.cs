using Abstractions.DTOs.Garage;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Garages.GetAllGarages;

public class GetAllGaragesHandler : IRequestHandler<GetAllGaragesRequest, Result<PaginatedResult<GarageDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllGaragesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<PaginatedResult<GarageDto>>> Handle(GetAllGaragesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var pagedResult = await _unitOfWork.Garages.GetPagedAsync(request.PageNumber, request.PageSize);
            var dtos = _mapper.Map<List<GarageDto>>(pagedResult.Items);
            var paginatedResult = new PaginatedResult<GarageDto>
            {
                Items = dtos,
                TotalCount = pagedResult.TotalCount,
                Skip = pagedResult.Skip,
                Take = pagedResult.Take
            };
            return Result<PaginatedResult<GarageDto>>.Success(paginatedResult);
        }
        catch (Exception ex)
        {
            return Result<PaginatedResult<GarageDto>>.Failure($"Failed to retrieve garage list: {ex.Message}");
        }
    }
}
