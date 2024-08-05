using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Services.UserDto;


public class UserDtoService(UserManager<User> userManager, IMapper mapper) : IUserDtoService
{
    public async Task<Common.Models.DTOs.UserDto> CreateUserDto(User user)
    {
        var userDto = mapper.Map<Common.Models.DTOs.UserDto>(user);
        var userRoles = await userManager.GetRolesAsync(user);
        userDto.Roles = [..userRoles];

        return userDto;
    }
}