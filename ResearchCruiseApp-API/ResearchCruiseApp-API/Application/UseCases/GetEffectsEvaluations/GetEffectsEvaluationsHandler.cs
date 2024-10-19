﻿using AutoMapper;
using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;

namespace ResearchCruiseApp_API.Application.UseCases.GetEffectsEvaluations;


public class GetEffectsEvaluationsHandler(
    IUserEffectsRepository userEffectsRepository,
    IMapper mapper)
    : IRequestHandler<GetEffectsEvaluationsQuery, Result<List<UserEffectDto>>>
{
    public async Task<Result<List<UserEffectDto>>> Handle(
        GetEffectsEvaluationsQuery request, CancellationToken cancellationToken)
    {
        var userEffects = await userEffectsRepository
            .GetAllByUserIdWithCruiseApplication((Guid)request.UserId, cancellationToken);

        return userEffects
            .Select(mapper.Map<UserEffectDto>)
            .ToList();
    }
}