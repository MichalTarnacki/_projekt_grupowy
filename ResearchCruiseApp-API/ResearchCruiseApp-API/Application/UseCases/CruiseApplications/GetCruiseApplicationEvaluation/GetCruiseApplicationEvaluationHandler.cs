﻿using MediatR;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.Common.ServiceResult;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Services.Factories.CruiseApplicationEvaluationDetailsDtos;
using ResearchCruiseApp_API.Application.Services.UserPermissionVerifier;

namespace ResearchCruiseApp_API.Application.UseCases.CruiseApplications.GetCruiseApplicationEvaluation;


public class GetCruiseApplicationEvaluationHandler(
    ICruiseApplicationsRepository cruiseApplicationsRepository,
    ICruiseApplicationEvaluationDetailsDtosFactory cruiseApplicationEvaluationDetailsDtosFactory,
    IUserPermissionVerifier userPermissionVerifier)
    : IRequestHandler<GetCruiseApplicationEvaluationQuery, Result<CruiseApplicationEvaluationDetailsDto>>
{
    public async Task<Result<CruiseApplicationEvaluationDetailsDto>> Handle(
        GetCruiseApplicationEvaluationQuery request, CancellationToken cancellationToken)
    {
        var cruiseApplication = await cruiseApplicationsRepository
            .GetByIdWithFormsAndFormAContent(request.Id, cancellationToken);
        if (cruiseApplication is null)
            return Error.ResourceNotFound();

        if (!await userPermissionVerifier.CanCurrentUserViewCruiseApplication(cruiseApplication))
            return Error.ResourceNotFound();
        
        return await cruiseApplicationEvaluationDetailsDtosFactory.Create(cruiseApplication, cancellationToken);
    }
}