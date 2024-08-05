using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.Models.DTOs.Account;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.ServicesInterfaces;


public interface IIdentityService
{
    Task<User?> GetUserById(Guid id);
    Task<Result> AcceptUser(Guid id);
    Task<Result> RegisterUserAsync(RegisterFormDto registerForm, string roleName, CancellationToken cancellationToken);
}