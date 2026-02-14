using AutoMapper;
using GarageService.Application.Abstractions;
using GarageService.Application.DTOs;
using GRRADO.Shared.Application.Common;
using MediatR;

namespace GarageService.Application.UseCases.Garages.UpdateGarage;

public class UpdateGarageHandler : IRequestHandler<UpdateGarageCommand, Result<GarageDto>>
{
    private readonly IGarageUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateGarageHandler(IGarageUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<GarageDto>> Handle(UpdateGarageCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Garages.GetByIdAsync(request.Id);

        if (entity is null)
            return Result<GarageDto>.Failure("Garage not found.");

        entity.Name = request.Request.Name;
        entity.City = request.Request.City;
        entity.Address = request.Request.Address;
        entity.PhoneNumber = request.Request.PhoneNumber;
        entity.GarageType = request.Request.GarageType;
        entity.EvSupported = request.Request.EvSupported;
        entity.Rating = request.Request.Rating;
        entity.OperatingHours = request.Request.OperatingHours;
        entity.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.Garages.UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        var dto = _mapper.Map<GarageDto>(entity);
        return Result<GarageDto>.Success(dto);
    }
}
