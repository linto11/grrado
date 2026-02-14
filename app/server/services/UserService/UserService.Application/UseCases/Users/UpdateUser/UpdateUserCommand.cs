using GRRADO.Shared.Application.Common;
using UserService.Application.DTOs;
using MediatR;

namespace UserService.Application.UseCases.Users.UpdateUser;

public class UpdateUserCommand : IRequest<Result<UserDto>>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string FamilyType { get; set; } = string.Empty;
    public string ExperienceLevel { get; set; } = string.Empty;
}
