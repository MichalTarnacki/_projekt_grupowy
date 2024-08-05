using MediatR;
using Microsoft.EntityFrameworkCore;
using ResearchCruiseApp_API.Application.Common.Models.DTOs;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.Services.UserDto;
using ResearchCruiseApp_API.Application.Services.UserPermissionVerifier;
using ResearchCruiseApp_API.Application.ServicesInterfaces;
using ResearchCruiseApp_API.Infrastructure.Persistence;

namespace ResearchCruiseApp_API.Application.UseCases.Users.GetAllUsers;


public class GetAllUsersHandler(
    IUserPermissionVerifier userPermissionVerifier,
    IUserDtoService userDtoService,
    IIdentityService identityService)
    : IRequestHandler<GetAllUsersQuery, Result<List<UserDto>>>
{
    public async Task<Result<List<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var allUsers = await identityService.GetAllUsers(cancellationToken);

        var userDtos = new List<UserDto>();
        foreach (var user in allUsers)
        {
            if (await userPermissionVerifier.CanUserAccessAsync(request.CurrentUser, user))
                userDtos.Add(await userDtoService.CreateUserDto(user));
        }
            
        return userDtos;
    }
}