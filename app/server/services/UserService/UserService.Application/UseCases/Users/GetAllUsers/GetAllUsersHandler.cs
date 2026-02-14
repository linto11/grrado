using AutoMapper;
using GRRADO.Shared.Application.Common;
using Microsoft.EntityFrameworkCore;
using UserService.Application.Abstractions;
using UserService.Application.DTOs;
using MediatR;

namespace UserService.Application.UseCases.Users.GetAllUsers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, Result<List<UserDto>>>
{
    private readonly IUserUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllUsersHandler(IUserUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await _unitOfWork.Users.GetAll()
                .Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
            var dtos = _mapper.Map<List<UserDto>>(entities);
            return Result<List<UserDto>>.Success(dtos);
        }
        catch (Exception ex)
        {
            return Result<List<UserDto>>.Failure($"Failed to get users: {ex.Message}");
        }
    }
}
