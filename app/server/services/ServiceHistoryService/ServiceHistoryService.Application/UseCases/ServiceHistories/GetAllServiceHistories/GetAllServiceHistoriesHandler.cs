using AutoMapper;
using GRRADO.Shared.Application.Common;
using Microsoft.EntityFrameworkCore;
using ServiceHistoryService.Application.Abstractions;
using ServiceHistoryService.Application.DTOs;
using MediatR;

namespace ServiceHistoryService.Application.UseCases.ServiceHistories.GetAllServiceHistories;

public class GetAllServiceHistoriesHandler : IRequestHandler<GetAllServiceHistoriesQuery, Result<List<ServiceHistoryDto>>>
{
    private readonly IServiceHistoryUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllServiceHistoriesHandler(IServiceHistoryUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<ServiceHistoryDto>>> Handle(GetAllServiceHistoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await _unitOfWork.ServiceHistories.GetAll()
                .Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
            var dtos = _mapper.Map<List<ServiceHistoryDto>>(entities);
            return Result<List<ServiceHistoryDto>>.Success(dtos);
        }
        catch (Exception ex)
        {
            return Result<List<ServiceHistoryDto>>.Failure($"Failed to get service histories: {ex.Message}");
        }
    }
}
