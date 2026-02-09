using Abstractions.DTOs.Garage;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Garages.GetGarageById;

public class GetGarageByIdHandler : IRequestHandler<GetGarageByIdRequest, Result<GarageDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetGarageByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<GarageDto>> Handle(GetGarageByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.Garages.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<GarageDto>.Failure($"Garage with ID {request.Id} not found");
            }
            var dto = _mapper.Map<GarageDto>(entity);
            return Result<GarageDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<GarageDto>.Failure($"Failed to retrieve garage: {ex.Message}");
        }
    }
}
