using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using ResearchCruiseApp_API.Application.Models.DTOs.Account;
using ResearchCruiseApp_API.Application.UseCases.Account.ChangePassword;
using ResearchCruiseApp_API.Application.UseCases.Account.ConfirmEmail;
using ResearchCruiseApp_API.Application.UseCases.Account.GetCurrentUser;
using ResearchCruiseApp_API.Application.UseCases.Account.Login;
using ResearchCruiseApp_API.Application.UseCases.Account.Register;
using ResearchCruiseApp_API.Infrastructure.Services.Identity;
using ResearchCruiseApp_API.Web.Common.Extensions;

namespace ResearchCruiseApp_API.Web.Controllers;


[Route("[controller]")]
[ApiController]
public class AccountController(
    UserManager<User> userManager,
    IConfiguration configuration,
    IMediator mediator)
    : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(
        [FromBody] RegisterFormDto registerForm)
    {
        var result = await mediator.Send(new RegisterCommand(registerForm));
        return result.Error is null
            ? Created()
            : this.CreateError(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginFormDto loginFormDto)
    {
        var result = await mediator.Send(new LoginCommand(loginFormDto));
        return result.Error is null
            ? Ok(result.Data)
            : this.CreateError(result);
    }
        
    [HttpPost("refresh")]
    public async
        Task<Results<Ok<AccessTokenResponse>, UnauthorizedHttpResult, SignInHttpResult, ChallengeHttpResult>>
        Refresh([FromBody] RefreshModel refreshModel, [FromServices] IServiceProvider serviceProvider)
    {
        var signInManager = serviceProvider.GetRequiredService<SignInManager<User>>();
        var bearerTokenOptions = serviceProvider.GetRequiredService<IOptionsMonitor<BearerTokenOptions>>();
        var refreshTokenProtector = bearerTokenOptions
            .Get(IdentityConstants.BearerScheme).RefreshTokenProtector;
        var refreshTicket = refreshTokenProtector.Unprotect(refreshModel.RefreshToken);
        var timeProvider = serviceProvider.GetRequiredService<TimeProvider>();
            
        // Reject the /refresh attempt with a 401 if the token expired or the security stamp validation fails
        if (refreshTicket?.Properties?.ExpiresUtc is not { } expiresUtc ||
            timeProvider.GetUtcNow() >= expiresUtc ||
            await signInManager.ValidateSecurityStampAsync(refreshTicket.Principal) is not { } user)
        {
            return TypedResults.Challenge();
        }
    
        var newPrincipal = await signInManager.CreateUserPrincipalAsync(user);
        return TypedResults.SignIn(newPrincipal, authenticationScheme: IdentityConstants.BearerScheme);
    }
        
    [HttpGet("confirmEmail")]
    public async Task<IActionResult> ConfirmEmail(
        [FromQuery] Guid userId,
        [FromQuery] string code,
        [FromQuery] string? changedEmail)
    {
        var result = await mediator.Send(new ConfirmEmailCommand(userId, code, changedEmail));
        return result.Error is null
            ? NoContent()
            : this.CreateError(result);
    }
        
    // [HttpPost("resendConfirmationEmail")]
    // public async Task<Ok> ResendConfirmationEmail(
    //     [FromBody] ResendConfirmationEmailModel resendConfirmationEmailModel,
    //     [FromServices] IServiceProvider serviceProvider)
    // {
    //     if (await userManager.FindByEmailAsync(resendConfirmationEmailModel.Email) is not { } user)
    //     {
    //         // Responding with 404 or similar would provide with unnecessary information
    //         return TypedResults.Ok();
    //     }
    //
    //     var emailSender = serviceProvider.GetRequiredService<IEmailSender>();
    //     await emailSender.SendAccountConfirmationMessageAsync(
    //         user, resendConfirmationEmailModel.Email, RoleName.CruiseManager, serviceProvider);
    //     return TypedResults.Ok();
    // }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetCurrentUser()
    {
        var result = await mediator.Send(new GetCurrentUserQuery());
        return result.Error is null
            ? Ok(result.Data)
            : this.CreateError(result);
    }
    
    [Authorize]
    [HttpPatch("password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordFormDto changePasswordFormDto)
    {
        var result = await mediator.Send(new ChangePasswordCommand(changePasswordFormDto));
        return result.Error is null
            ? NoContent()
            : this.CreateError(result);
    }
}