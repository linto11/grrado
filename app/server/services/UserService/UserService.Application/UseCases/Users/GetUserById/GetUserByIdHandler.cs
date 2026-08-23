using AutoMapper;
using GRRADO.Shared.Abstractions.Caching;
using GRRADO.Shared.Application.Common;
using UserService.Application.Abstractions;
using UserService.Application.DTOs;
using MediatR;

namespace UserService.Application.UseCases.Users.GetUserById;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
{
    private readonly IUserUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheService _cache;

    public GetUserByIdHandler(IUserUnitOfWork unitOfWork, IMapper mapper, ICacheService cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cache;
    }

    public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var cacheKey = $"user:{request.Id}";
            var cached = await _cache.GetAsync<UserDto>(cacheKey, cancellationToken);
            if (cached != null)
                return Result<UserDto>.Success(cached);

            var entity = await _unitOfWork.Users.GetByIdAsync(request.Id);
            if (entity == null)
                return Result<UserDto>.Failure("User not found");

            var dto = _mapper.Map<UserDto>(entity);
            await _cache.SetAsync(cacheKey, dto, cancellationToken: cancellationToken);
            return Result<UserDto>.Success(dto);
        }
        catch (Exception ex)
        {
            return Result<UserDto>.Failure($"Failed to get user: {ex.Message}");
        }
    }
}
