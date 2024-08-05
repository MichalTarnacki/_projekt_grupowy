using MediatR;
using Microsoft.AspNetCore.Identity;
using ResearchCruiseApp_API.Application.Common.Models.DTOs;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.Services.UserDto;
using ResearchCruiseApp_API.Application.Services.UserPermissionVerifier;
using Entities_User = ResearchCruiseApp_API.Domain.Entities.User;

namespace ResearchCruiseApp_API.Application.UseCases.Users.GetUserById;

public class GetUserByIdHandler(
    UserManager<Entities_User> userManager,
    IUserPermissionVerifier userPermissionVerifier,
    IUserDtoService userDtoService)
    : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
{
    public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id.ToString());
        
        if (user == null)
            return Error.NotFound();
        if (await userPermissionVerifier.CanUserAccessAsync(request.CurrentUser, user))
            return Error.NotFound(); // Returning Forbidden would provide with too much information
  
        return await userDtoService.CreateUserDto(user);
    }
}