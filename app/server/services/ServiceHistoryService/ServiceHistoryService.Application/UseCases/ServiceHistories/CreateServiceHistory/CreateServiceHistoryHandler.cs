using AutoMapper;
using GRRADO.Shared.Application.Common;
using ServiceHistoryService.Application.Abstractions;
using ServiceHistoryService.Application.DTOs;
using ServiceHistoryService.Domain.Entities;
using MediatR;

namespace ServiceHistoryService.Application.UseCases.ServiceHistories.CreateServiceHistory;

public class CreateServiceHistoryHandler : IRequestHandler<CreateServiceHistoryCommand, Result<ServiceHistoryDto>>
{
    private readonly IServiceHistoryUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateServiceHistoryHandler(IServiceHistoryUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ServiceHistoryDto>> Handle(CreateServiceHistoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<ServiceHistory>(request);
            await _unitOfWork.ServiceHistories.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<ServiceHistoryDto>.Success(_mapper.Map<ServiceHistoryDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<ServiceHistoryDto>.Failure($"Failed to create service history: {ex.Message}");
        }
    }
}
