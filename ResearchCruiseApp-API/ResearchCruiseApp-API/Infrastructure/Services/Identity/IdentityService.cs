using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.Models.DTOs.Account;
using ResearchCruiseApp_API.Application.ServicesInterfaces;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Infrastructure.Services.Identity;


public class IdentityService(
    UserManager<User> userManager,
    IUserStore<User> userStore,
    IEmailSender emailSender)
    : IIdentityService
{
    public async Task<User?> GetUserById(Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());
        return user;
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
        
        await emailSender.SendAccountAcceptedMessage(user);
        
        return Result.Empty;
    }
    
    public async Task<Result> RegisterUserAsync(
        RegisterFormDto registerForm,
        string roleName,
        CancellationToken cancellationToken)
    {
        var emailAddressAttribute = new EmailAddressAttribute();
        
        if (!userManager.SupportsUserEmail)
            return Error.ServiceUnavailable();

        if (string.IsNullOrEmpty(registerForm.Email) || !emailAddressAttribute.IsValid(registerForm.Email))
            return Error.BadRequest("E-mail jest niepoprawny");

        var user = await CreateUser(registerForm, cancellationToken);
        var identityResult = await userManager.CreateAsync(user, registerForm.Password);
        await userManager.AddToRoleAsync(user, roleName);

        var emailConfirmationCode = await CreateEmailConfirmationCode(user, false);
        await emailSender.SendEmailConfirmationEmail(user, roleName, emailConfirmationCode);

        return identityResult.ToApplicationResult();
    }


    private async Task<User> CreateUser(RegisterFormDto registerForm, CancellationToken cancellationToken)
    {
        var emailStore = (IUserEmailStore<User>)userStore;
        
        var user = new User();
        await userStore.SetUserNameAsync(user, registerForm.Email, cancellationToken);
        await emailStore.SetEmailAsync(user, registerForm.Email, cancellationToken);
        user.FirstName = registerForm.FirstName;
        user.LastName = registerForm.LastName;

        return user;
    }

    private async Task<string> CreateEmailConfirmationCode(User user, bool changeEmail)
    {
        var code = changeEmail
            ? await userManager.GenerateChangeEmailTokenAsync(user, user.Email!)
            : await userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        return code;
    }
}