using Abstractions.DTOs.ServiceHistory;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.ServiceHistories.UpdateServiceHistory;

public class UpdateServiceHistoryHandler : IRequestHandler<UpdateServiceHistoryRequest, Result<ServiceHistoryDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateServiceHistoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ServiceHistoryDto>> Handle(UpdateServiceHistoryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ServiceHistories.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<ServiceHistoryDto>.Failure($"ServiceHistory with ID {request.Id} not found");
            }
            _mapper.Map(request, entity);
            await _unitOfWork.ServiceHistories.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<ServiceHistoryDto>(entity);
            return Result<ServiceHistoryDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<ServiceHistoryDto>.Failure($"Failed to update serviceHistory: {ex.Message}");
        }
    }
}
