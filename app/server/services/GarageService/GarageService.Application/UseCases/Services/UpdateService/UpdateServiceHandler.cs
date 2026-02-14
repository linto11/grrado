using AutoMapper;
using GarageService.Application.Abstractions;
using GarageService.Application.DTOs;
using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Services.UpdateService;

public class UpdateServiceHandler : IRequestHandler<UpdateServiceCommand, Result<ServiceDto>>
{
    private readonly IGarageUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateServiceHandler(IGarageUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ServiceDto>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Services.GetByIdAsync(request.Id);

        if (entity is null)
            return Result<ServiceDto>.Failure("Service not found.");

        entity.GarageId = request.Request.GarageId;
        entity.ServiceName = request.Request.ServiceName;
        entity.Category = request.Request.Category;
        entity.AvgCostAed = request.Request.AvgCostAed;
        entity.SkillLevel = request.Request.SkillLevel;
        entity.Description = request.Request.Description;
        entity.EstimatedDurationMinutes = request.Request.EstimatedDurationMinutes;
        entity.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.Services.UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        var dto = _mapper.Map<ServiceDto>(entity);
        return Result<ServiceDto>.Success(dto);
    }
}
