using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using ResearchCruiseApp_API.Application.Common.Models.DTOs;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.ExternalServices;
using ResearchCruiseApp_API.Application.Models.DTOs.Account;
using ResearchCruiseApp_API.Application.Models.DTOs.Users;

namespace ResearchCruiseApp_API.Infrastructure.Services.Identity;


public class IdentityService(
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager,
    IEmailSender emailSender,
    ICurrentUserService currentUserService,
    IMapper mapper)
    : IIdentityService
{
    public async Task<UserDto?> GetUserDtoById(Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());
        return user is null
            ? null
            : CreateUserDto(user);
    }

    public Task<List<UserDto>> GetAllUsersDtos(CancellationToken cancellationToken)
    {
        return userManager.Users
            .Select(user => CreateUserDto(user))
            .ToListAsync(cancellationToken);
    }
    
    public async Task<bool> UserWithEmailExists(string email)
    {
        return await userManager.FindByEmailAsync(email) is not null;
    }
    
    public async Task<Result> AcceptUser(Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());
        if (user is null)
            return Error.NotFound();
        
        user.Accepted = true;
        
        var identityResult = await userManager.UpdateAsync(user);
        if (!identityResult.Succeeded)
            return identityResult.ToApplicationResult();
        
        await emailSender.SendAccountAcceptedMessage(CreateUserDto(user));
        
        return Result.Empty;
    }
    
    public async Task<Result> RegisterUser(
        RegisterFormDto registerForm, string roleName, CancellationToken cancellationToken)
    {
        var emailAddressAttribute = new EmailAddressAttribute();
        
        if (!userManager.SupportsUserEmail)
            return Error.ServiceUnavailable();

        if (string.IsNullOrEmpty(registerForm.Email) || !emailAddressAttribute.IsValid(registerForm.Email))
            return Error.BadRequest("E-mail jest niepoprawny");

        var user = CreateUser(registerForm);
        var identityResult = await userManager.CreateAsync(user, registerForm.Password);
        if (!identityResult.Succeeded)
            return identityResult.ToApplicationResult();
        
        identityResult = await userManager.AddToRoleAsync(user, roleName);
        if (!identityResult.Succeeded)
            return identityResult.ToApplicationResult();

        var emailConfirmationCode = await CreateEmailConfirmationCode(user, false);
        await emailSender.SendEmailConfirmationEmail(CreateUserDto(user), roleName, emailConfirmationCode);

        return identityResult.ToApplicationResult();
    }

    public async Task<Result> AddUserWithRole(AddUserFormDto addUserFormDto, string password, string roleName)
    {
        var user = CreateUser(addUserFormDto);
        var identityResult = await userManager.CreateAsync(user, password);
        if (!identityResult.Succeeded)
            return identityResult.ToApplicationResult();
        
        identityResult = await userManager.AddToRoleAsync(user, roleName);
        if (!identityResult.Succeeded)
            return identityResult.ToApplicationResult();
        
        var emailConfirmationCode = await CreateEmailConfirmationCode(user, false);
        await emailSender.SendEmailConfirmationEmail(CreateUserDto(user), roleName, emailConfirmationCode);
        
        return Result.Empty;
    }

    public async Task<Result> AddRoleToUser(Guid userId, string roleName)
    {
        var user = await userManager.FindByEmailAsync(userId.ToString());
        if (user is null)
            return Error.NotFound();
        
        var result = await userManager.AddToRoleAsync(user, roleName);
        return result.ToApplicationResult();
    }

    public async Task<Result> RemoveRoleFromUser(Guid userId, string roleName)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());
        if (user is null)
            return Error.NotFound();
        
        var result = await userManager.RemoveFromRoleAsync(user, roleName);
        return result.ToApplicationResult();
    }

    public async Task<IList<string>> GetUserRolesNames(Guid userId)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());
        if (user is null)
            return [];
        
        return await userManager.GetRolesAsync(user);
    }
    
    public async Task<IList<string>> GetCurrentUserRoleNames()
    {
        var currentUserId = currentUserService.GetId();
        if (currentUserId is null)
            return [];

        var currentUser = await userManager.FindByIdAsync(currentUserId.ToString()!);
        if (currentUser is null)
            return [];

        return await userManager.GetRolesAsync(currentUser);
    }
    
    public Task<List<string?>> GetAllRoleNames(CancellationToken cancellationToken)
    {
        return roleManager.Roles
            .Select(role => role.Name)
            .ToListAsync(cancellationToken);
    }
    

    private static User CreateUser(RegisterFormDto registerFormDto) =>
        CreateUser(registerFormDto.Email, registerFormDto.FirstName, registerFormDto.LastName, false);

    private static User CreateUser(AddUserFormDto addUserFormDto) =>
        CreateUser(addUserFormDto.Email, addUserFormDto.FirstName, addUserFormDto.LastName, true);

    private static User CreateUser(string email, string firstName, string lastName, bool accepted)
    {
        return new User
        {
            UserName = email,
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Accepted = accepted
        };
    }

    private UserDto CreateUserDto(User user) =>
        mapper.Map<UserDto>(user);
    
    private async Task<string> CreateEmailConfirmationCode(User user, bool changeEmail)
    {
        var code = changeEmail
            ? await userManager.GenerateChangeEmailTokenAsync(user, user.Email!)
            : await userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        return code;
    }
}