using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Services.UserDto;


public interface IUserDtoService
{
    Task<Common.Models.DTOs.UserDto> CreateUserDto(User user);
}