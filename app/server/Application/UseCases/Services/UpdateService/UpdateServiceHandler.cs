using Abstractions.DTOs.Service;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Services.UpdateService;

public class UpdateServiceHandler : IRequestHandler<UpdateServiceRequest, Result<ServiceDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateServiceHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ServiceDto>> Handle(UpdateServiceRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.Services.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return Result<ServiceDto>.Failure($"Service with ID {request.Id} not found");
            }
            _mapper.Map(request, entity);
            await _unitOfWork.Services.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<ServiceDto>(entity);
            return Result<ServiceDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<ServiceDto>.Failure($"Failed to update service: {ex.Message}");
        }
    }
}
