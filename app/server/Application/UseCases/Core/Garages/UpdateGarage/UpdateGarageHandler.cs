using Abstractions.DTOs.Garage;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Core.Garages.UpdateGarage;

public class UpdateGarageHandler : IRequestHandler<UpdateGarageRequest, Result<GarageDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateGarageHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<GarageDto>> Handle(UpdateGarageRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.Garages.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GarageDto>.Failure($"Garage with ID {request.Id} not found");
            }
            _mapper.Map(request, entity);
            await _unitOfWork.Garages.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<GarageDto>(entity);
            return Result<GarageDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<GarageDto>.Failure($"Failed to update garage: {ex.Message}");
        }
    }
}
