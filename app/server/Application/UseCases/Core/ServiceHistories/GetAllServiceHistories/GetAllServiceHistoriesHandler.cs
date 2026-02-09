using Abstractions.DTOs.ServiceHistory;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Core.ServiceHistories.GetAllServiceHistories;

public class GetAllServiceHistoriesHandler : IRequestHandler<GetAllServiceHistoriesRequest, Result<PaginatedResult<ServiceHistoryDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllServiceHistoriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<PaginatedResult<ServiceHistoryDto>>> Handle(GetAllServiceHistoriesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var pagedResult = await _unitOfWork.ServiceHistories.GetPagedAsync(request.PageNumber, request.PageSize);
            var dtos = _mapper.Map<List<ServiceHistoryDto>>(pagedResult.Items);
            var paginatedResult = new PaginatedResult<ServiceHistoryDto>
            {
                Items = dtos,
                TotalCount = pagedResult.TotalCount,
                Skip = pagedResult.Skip,
                Take = pagedResult.Take
            };
            return Result<PaginatedResult<ServiceHistoryDto>>.Success(paginatedResult);
        }
        catch (Exception ex)
        {
            return Result<PaginatedResult<ServiceHistoryDto>>.Failure($"Failed to retrieve serviceHistory list: {ex.Message}");
        }
    }
}
