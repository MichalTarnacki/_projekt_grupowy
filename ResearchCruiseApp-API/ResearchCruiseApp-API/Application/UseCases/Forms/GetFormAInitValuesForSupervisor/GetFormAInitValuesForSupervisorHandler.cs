﻿using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.DTOs.Forms;
using ResearchCruiseApp_API.Application.Services.CruiseApplications;
using ResearchCruiseApp_API.Application.Services.Factories.FormAInitValuesDtos;

namespace ResearchCruiseApp_API.Application.UseCases.Forms.GetFormAInitValuesForSupervisor;


public class GetFormAInitValuesForSupervisorHandler(
    ICruiseApplicationsRepository cruiseApplicationsRepository,
    ICruiseApplicationsService cruiseApplicationsService,
    IFormAInitValuesDtosFactory formAInitValuesDtosFactory)
    : IRequestHandler<GetFormAInitValuesForSupervisorQuery, Result<FormAInitValuesDto>>
{
    public async Task<Result<FormAInitValuesDto>> Handle(
        GetFormAInitValuesForSupervisorQuery request, CancellationToken cancellationToken)
    {
        var cruiseApplication = await cruiseApplicationsRepository
            .GetByIdWithFormA(request.CruiseApplicationId, cancellationToken);
        if (cruiseApplication?.FormA is null)
            return Error.ResourceNotFound();

        if (!cruiseApplicationsService.CheckSupervisorCode(cruiseApplication.SupervisorCode, request.SupervisorCode))
            return Error.ResourceNotFound(); // Returning 401 or similar would give too much information

        var formAInitValuesDto = await formAInitValuesDtosFactory
            .CreateForSupervisor(cruiseApplication, cancellationToken);
        return formAInitValuesDto;
    }
}