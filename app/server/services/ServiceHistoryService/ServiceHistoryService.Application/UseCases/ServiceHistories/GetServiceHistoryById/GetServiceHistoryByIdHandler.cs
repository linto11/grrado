using AutoMapper;
using GRRADO.Shared.Application.Common;
using ServiceHistoryService.Application.Abstractions;
using ServiceHistoryService.Application.DTOs;
using MediatR;

namespace ServiceHistoryService.Application.UseCases.ServiceHistories.GetServiceHistoryById;

public class GetServiceHistoryByIdHandler : IRequestHandler<GetServiceHistoryByIdQuery, Result<ServiceHistoryDto>>
{
    private readonly IServiceHistoryUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetServiceHistoryByIdHandler(IServiceHistoryUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ServiceHistoryDto>> Handle(GetServiceHistoryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ServiceHistories.GetByIdAsync(request.Id);
            if (entity == null)
                return Result<ServiceHistoryDto>.Failure($"ServiceHistory with id {request.Id} not found");
            return Result<ServiceHistoryDto>.Success(_mapper.Map<ServiceHistoryDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<ServiceHistoryDto>.Failure($"Failed to get service history: {ex.Message}");
        }
    }
}
