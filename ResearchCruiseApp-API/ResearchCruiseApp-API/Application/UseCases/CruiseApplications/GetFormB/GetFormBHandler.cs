﻿using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Services.Factories.FormBDtos;
using ResearchCruiseApp_API.Application.Services.UserPermissionVerifier;

namespace ResearchCruiseApp_API.Application.UseCases.CruiseApplications.GetFormB;


public class GetFormBHandler(
    ICruiseApplicationsRepository cruiseApplicationsRepository,
    IFormBDtosFactory formBDtosFactory,
    IUserPermissionVerifier userPermissionVerifier)
    : IRequestHandler<GetFormBQuery, Result<FormBDto>>
{
    public async Task<Result<FormBDto>> Handle(GetFormBQuery request, CancellationToken cancellationToken)
    {
        var cruiseApplication = await cruiseApplicationsRepository
            .GetByIdWithFormAAndFormBContent(request.CruiseApplicationId, cancellationToken);
        if (cruiseApplication?.FormB is null)
            return Error.NotFound();

        if (!await userPermissionVerifier.CanCurrentUserViewForm(cruiseApplication))
            return Error.NotFound();

        var formBDto = formBDtosFactory.Create(cruiseApplication.FormB, cancellationToken);
        return formBDto;
    }
}