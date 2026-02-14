using AutoMapper;
using GRRADO.Shared.Application.Common;
using ServiceHistoryService.Application.Abstractions;
using ServiceHistoryService.Application.DTOs;
using MediatR;

namespace ServiceHistoryService.Application.UseCases.ServiceHistories.UpdateServiceHistory;

public class UpdateServiceHistoryHandler : IRequestHandler<UpdateServiceHistoryCommand, Result<ServiceHistoryDto>>
{
    private readonly IServiceHistoryUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateServiceHistoryHandler(IServiceHistoryUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ServiceHistoryDto>> Handle(UpdateServiceHistoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.ServiceHistories.GetByIdAsync(request.Id);
            if (entity == null)
                return Result<ServiceHistoryDto>.Failure("Service history not found");

            entity.VehicleId = request.VehicleId;
            entity.GarageId = request.GarageId;
            entity.ServiceId = request.ServiceId;
            entity.ServiceDate = request.ServiceDate;
            entity.MileageKm = request.MileageKm;
            entity.CostAed = request.CostAed;
            entity.Outcome = request.Outcome;
            entity.Notes = request.Notes;
            entity.TechnicianId = request.TechnicianId;

            await _unitOfWork.ServiceHistories.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result<ServiceHistoryDto>.Success(_mapper.Map<ServiceHistoryDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<ServiceHistoryDto>.Failure($"Failed to update service history: {ex.Message}");
        }
    }
}
