using System.IdentityModel.Tokens.Jwt;
using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.ExternalServices;
using ResearchCruiseApp_API.Application.Models.DTOs.Account;

namespace ResearchCruiseApp_API.Application.UseCases.Account.Login;


internal class LoginHandler(IIdentityService identityService) : IRequestHandler<LoginCommand, Result<LoginResponseDto>>
{
    public async Task<Result<LoginResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (!await identityService.CanUserLogin(request.LoginFormDto.Email, request.LoginFormDto.Password))
            return Error.Unauthorized();

        var tokenResult = await identityService.GetAccessToken(request.LoginFormDto.Email);
        if (tokenResult.Error is not null)
            return tokenResult.Error;
        
        return new LoginResponseDto
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(tokenResult.Data),
            ExpiresIn = tokenResult.Data?.ValidTo ?? DateTime.Now,
            RefreshToken = string.Empty
        };
    }
}