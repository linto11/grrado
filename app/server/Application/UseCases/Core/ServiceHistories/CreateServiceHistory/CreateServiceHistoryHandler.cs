using Abstractions.DTOs.ServiceHistory;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Core.ServiceHistories.CreateServiceHistory;

public class CreateServiceHistoryHandler : IRequestHandler<CreateServiceHistoryRequest, Result<ServiceHistoryDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateServiceHistoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ServiceHistoryDto>> Handle(CreateServiceHistoryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Domain.Entities.ServiceHistory>(request);
            await _unitOfWork.ServiceHistories.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<ServiceHistoryDto>(entity);
            return Result<ServiceHistoryDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<ServiceHistoryDto>.Failure($"Failed to create serviceHistory: {ex.Message}");
        }
    }
}
