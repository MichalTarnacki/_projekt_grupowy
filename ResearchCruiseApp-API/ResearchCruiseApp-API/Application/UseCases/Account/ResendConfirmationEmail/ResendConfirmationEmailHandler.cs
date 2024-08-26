﻿using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.ExternalServices;
using ResearchCruiseApp_API.Domain.Common.Constants;

namespace ResearchCruiseApp_API.Application.UseCases.Account.ResendConfirmationEmail;


public class ResendConfirmationEmailHandler(
    IIdentityService identityService)
    : IRequestHandler<ResendConfirmationEmailCommand, Result>
{
    public async Task<Result> Handle(ResendConfirmationEmailCommand request, CancellationToken cancellationToken)
    {
        await identityService.ResendEmailConfirmationEmail(request.EmailDto.Email, RoleName.CruiseManager);
        return Result.Empty;
    }
}