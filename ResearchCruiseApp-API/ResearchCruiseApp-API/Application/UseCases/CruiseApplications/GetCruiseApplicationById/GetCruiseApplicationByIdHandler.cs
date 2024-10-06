using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Services.Factories.CruiseApplicationDtos;
using ResearchCruiseApp_API.Application.Services.UserPermissionVerifier;

namespace ResearchCruiseApp_API.Application.UseCases.CruiseApplications.GetCruiseApplicationById;


public class GetCruiseApplicationByIdHandler(
    ICruiseApplicationDtosFactory cruiseApplicationDtosFactory,
    ICruiseApplicationsRepository cruiseApplicationsRepository,
    IUserPermissionVerifier userPermissionVerifier)
    : IRequestHandler<GetCruiseApplicationByIdQuery, Result<CruiseApplicationDto>>
{
    public async Task<Result<CruiseApplicationDto>> Handle(
        GetCruiseApplicationByIdQuery request,
        CancellationToken cancellationToken)
    {
        var cruiseApplication =
            await cruiseApplicationsRepository.GetByIdWithFormsAndFormAContent(request.Id, cancellationToken);

        if (cruiseApplication is null)
            return Error.NotFound();

        
        var cruiseApplicationDto = await userPermissionVerifier.CanCurrentUserViewCruiseApplication(cruiseApplication) 
            ? await cruiseApplicationDtosFactory.Create(cruiseApplication): null;
        
        return cruiseApplicationDto;
    }
}