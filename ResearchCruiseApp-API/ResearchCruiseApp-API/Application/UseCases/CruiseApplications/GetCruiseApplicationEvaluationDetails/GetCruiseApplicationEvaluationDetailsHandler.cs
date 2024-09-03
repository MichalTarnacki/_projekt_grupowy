using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Services.Factories.CruiseApplicationEvaluationDetailsDtos;

namespace ResearchCruiseApp_API.Application.UseCases.CruiseApplications.GetCruiseApplicationEvaluationDetails;


public class GetCruiseApplicationEvaluationDetailsHandler(
    ICruiseApplicationsRepository cruiseApplicationsRepository,
    ICruiseApplicationEvaluationDetailsDtosFactory cruiseApplicationEvaluationDetailsDtosFactory)
    : IRequestHandler<GetCruiseApplicationEvaluationDetailsQuery, Result<CruiseApplicationEvaluationDetailsDto>>
{
    public async Task<Result<CruiseApplicationEvaluationDetailsDto>> Handle(
        GetCruiseApplicationEvaluationDetailsQuery request, CancellationToken cancellationToken)
    {
        var cruiseApplication = await cruiseApplicationsRepository
            .GetByIdWithFormsAndFormAContent(request.Id, cancellationToken);
        if (cruiseApplication is null)
            return Error.NotFound();

        return await cruiseApplicationEvaluationDetailsDtosFactory.Create(cruiseApplication, cancellationToken);
    }
}