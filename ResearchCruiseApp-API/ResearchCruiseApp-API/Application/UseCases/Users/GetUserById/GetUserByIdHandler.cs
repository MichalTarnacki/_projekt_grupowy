using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.DTOs;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.Services.UserDto;
using ResearchCruiseApp_API.Application.Services.UserPermissionVerifier;
using ResearchCruiseApp_API.Application.ServicesInterfaces;

namespace ResearchCruiseApp_API.Application.UseCases.Users.GetUserById;

public class GetUserByIdHandler(
    IUserPermissionVerifier userPermissionVerifier,
    IUserDtoService userDtoService,
    IIdentityService identityService)
    : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
{
    public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await identityService.GetUserById(request.Id);
        
        if (user == null)
            return Error.NotFound();
        if (await userPermissionVerifier.CanUserAccessAsync(request.CurrentUser, user))
            return Error.NotFound(); // Returning Forbidden would provide with too much information
  
        return await userDtoService.CreateUserDto(user);
    }
}