using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResearchCruiseApp_API.Application.Models.DTOs.Account;
using ResearchCruiseApp_API.Application.UseCases.Account.ChangePassword;
using ResearchCruiseApp_API.Application.UseCases.Account.ConfirmEmail;
using ResearchCruiseApp_API.Application.UseCases.Account.EnablePasswordReset;
using ResearchCruiseApp_API.Application.UseCases.Account.GetCurrentUser;
using ResearchCruiseApp_API.Application.UseCases.Account.Login;
using ResearchCruiseApp_API.Application.UseCases.Account.Refresh;
using ResearchCruiseApp_API.Application.UseCases.Account.Register;
using ResearchCruiseApp_API.Application.UseCases.Account.ResendConfirmationEmail;
using ResearchCruiseApp_API.Application.UseCases.Account.ResetPassword;
using ResearchCruiseApp_API.Web.Common.Extensions;

namespace ResearchCruiseApp_API.Web.Controllers;


[Route("[controller]")]
[ApiController]
public class AccountController(IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(
        [FromBody] RegisterFormDto registerForm)
    {
        var result = await mediator.Send(new RegisterCommand(registerForm));
        return result.IsSuccess
            ? Created()
            : this.CreateError(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginFormDto loginFormDto)
    {
        var result = await mediator.Send(new LoginCommand(loginFormDto));
        return result.IsSuccess
            ? Ok(result.Data)
            : this.CreateError(result);
    }
        
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshDto refreshDto)
    {
        var result = await mediator.Send(new RefreshCommand(refreshDto));
        return result.IsSuccess
            ? Ok(result.Data)
            : this.CreateError(result);
    }
        
    [HttpGet("emailConfirmation")]
    public async Task<IActionResult> ConfirmEmail(
        [FromQuery] Guid userId,
        [FromQuery] string code,
        [FromQuery] string? changedEmail)
    {
        var result = await mediator.Send(new ConfirmEmailCommand(userId, code, changedEmail));
        return result.IsSuccess
            ? NoContent()
            : this.CreateError(result);
    }
        
    [HttpPost("emailConfirmationRequest")]
    public async Task<IActionResult> ResendEmailConfirmationEmail([FromBody] EmailDto emailDto)
    {
        var result = await mediator.Send(new ResendConfirmationEmailCommand(emailDto));
        return result.IsSuccess
            ? NoContent()
            : this.CreateError(result);
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetCurrentUser()
    {
        var result = await mediator.Send(new GetCurrentUserQuery());
        return result.IsSuccess
            ? Ok(result.Data)
            : this.CreateError(result);
    }
    
    [Authorize]
    [HttpPatch("password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordFormDto changePasswordFormDto)
    {
        var result = await mediator.Send(new ChangePasswordCommand(changePasswordFormDto));
        return result.IsSuccess
            ? NoContent()
            : this.CreateError(result);
    }

    [HttpPost("forgotPassword")]
    public async Task<IActionResult> EnablePasswordReset([FromBody] ForgotPasswordFormDto forgotPasswordFormDto)
    {
        var result = await mediator.Send(new EnablePasswordResetCommand(forgotPasswordFormDto));
        return result.IsSuccess
            ? NoContent()
            : this.CreateError(result);
    }

    [HttpPost("passwordReset")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordFormDto resetPasswordFormDto)
    {
        var result = await mediator.Send(new ResetPasswordCommand(resetPasswordFormDto));
        return result.IsSuccess
            ? NoContent()
            : this.CreateError(result);
    }
}