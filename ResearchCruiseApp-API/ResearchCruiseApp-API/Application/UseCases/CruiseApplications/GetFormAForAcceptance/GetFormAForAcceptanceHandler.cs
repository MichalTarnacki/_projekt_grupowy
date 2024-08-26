using MediatR;
using Microsoft.IdentityModel.Tokens;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.SharedServices.Factories.FormADtos;

namespace ResearchCruiseApp_API.Application.UseCases.CruiseApplications.GetFormAForAcceptance;


public class GetFormAForAcceptanceHandler(
    ICruiseApplicationsRepository cruiseApplicationsRepository,
    IFormADtosFactory formADtosFactory) 
    : IRequestHandler<GetFormAForAcceptanceQuery, Result<FormADto>>
{
    public async Task<Result<FormADto>> Handle(GetFormAForAcceptanceQuery request, CancellationToken cancellationToken)
    {
        var cruiseApplication = await cruiseApplicationsRepository
            .GetByIdWithFormAContent(request.CruiseApplicationId, cancellationToken);
        if (cruiseApplication?.FormA is null)
            return Error.NotFound();
        
        var supervisorCodeBytes = Base64UrlEncoder.DecodeBytes(request.SupervisorCode);
        if (supervisorCodeBytes is null)
            return Error.NotFound();
        
        if (!cruiseApplication.SupervisorCode.SequenceEqual(supervisorCodeBytes))
            return Error.NotFound(); // Returning 401 or similar would give too much information

        return await formADtosFactory.Create(cruiseApplication.FormA);
    }
}
