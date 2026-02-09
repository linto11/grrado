using Abstractions.DTOs.Service;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Core.Services.GetAllServices;

public class GetAllServicesHandler : IRequestHandler<GetAllServicesRequest, Result<PaginatedResult<ServiceDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllServicesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<PaginatedResult<ServiceDto>>> Handle(GetAllServicesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var pagedResult = await _unitOfWork.Services.GetPagedAsync(request.PageNumber, request.PageSize);
            var dtos = _mapper.Map<List<ServiceDto>>(pagedResult.Items);
            var paginatedResult = new PaginatedResult<ServiceDto>
            {
                Items = dtos,
                TotalCount = pagedResult.TotalCount,
                Skip = pagedResult.Skip,
                Take = pagedResult.Take
            };
            return Result<PaginatedResult<ServiceDto>>.Success(paginatedResult);
        }
        catch (Exception ex)
        {
            return Result<PaginatedResult<ServiceDto>>.Failure($"Failed to retrieve service list: {ex.Message}");
        }
    }
}
