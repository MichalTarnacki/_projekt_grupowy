﻿using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.Models.DTOs.Account;

namespace ResearchCruiseApp_API.Application.UseCases.Account.ResendConfirmationEmail;


public record ResendConfirmationEmailCommand(EmailDto EmailDto) : IRequest<Result>;