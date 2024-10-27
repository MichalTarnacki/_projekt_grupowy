﻿using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.Models.DTOs.Account;

namespace ResearchCruiseApp_API.Application.UseCases.Account.EnablePasswordReset;


public record EnablePasswordResetCommand(ForgotPasswordFormDto ForgotPasswordFormDto) : IRequest<Result>;