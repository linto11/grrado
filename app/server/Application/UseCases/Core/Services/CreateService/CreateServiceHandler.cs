using Abstractions.DTOs.Service;
using Abstractions.Persistence;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Core.Services.CreateService;

public class CreateServiceHandler : IRequestHandler<CreateServiceRequest, Result<ServiceDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateServiceHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ServiceDto>> Handle(CreateServiceRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Domain.Entities.Service>(request);
            await _unitOfWork.Services.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var dto = _mapper.Map<ServiceDto>(entity);
            return Result<ServiceDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<ServiceDto>.Failure($"Failed to create service: {ex.Message}");
        }
    }
}
