using ResearchCruiseApp_API.Application.Common.Models.DTOs;
using ResearchCruiseApp_API.Domain.Entities;
using ResearchCruiseApp_API.Infrastructure.Services.Identity;

namespace ResearchCruiseApp_API.Application.SharedServices.UserDtos;


public interface IUserDtosService
{
    Task<UserDto> CreateUserDto(User user);
}