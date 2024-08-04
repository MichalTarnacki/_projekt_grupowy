using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.Models.DTOs.Account;

namespace ResearchCruiseApp_API.Application.ServicesInterfaces;


public interface IIdentityService
{
    Task<Result> RegisterUserAsync(RegisterFormDto registerForm, string roleName, CancellationToken cancellationToken);
}