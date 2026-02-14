using AutoMapper;
using GRRADO.Shared.Application.Common;
using UserService.Application.Abstractions;
using UserService.Application.DTOs;
using MediatR;

namespace UserService.Application.UseCases.Users.GetUserById;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
{
    private readonly IUserUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserByIdHandler(IUserUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _unitOfWork.Users.GetByIdAsync(request.Id);
            if (entity == null)
                return Result<UserDto>.Failure("User not found");
            return Result<UserDto>.Success(_mapper.Map<UserDto>(entity));
        }
        catch (Exception ex)
        {
            return Result<UserDto>.Failure($"Failed to get user: {ex.Message}");
        }
    }
}
