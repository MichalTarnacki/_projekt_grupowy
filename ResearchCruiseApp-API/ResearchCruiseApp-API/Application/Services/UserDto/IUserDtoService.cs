using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Services.UserDto;


public interface IUserDtoService
{
    Task<Models.DTOs.Users.UserDto> CreateUserDto(User user);
}