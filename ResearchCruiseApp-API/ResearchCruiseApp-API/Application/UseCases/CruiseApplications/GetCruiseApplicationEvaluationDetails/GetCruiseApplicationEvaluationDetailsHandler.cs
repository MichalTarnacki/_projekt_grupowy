using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;

namespace ResearchCruiseApp_API.Application.UseCases.CruiseApplications.GetCruiseApplicationEvaluationDetails;


public class GetCruiseApplicationEvaluationDetailsHandler
    : IRequestHandler<GetCruiseApplicationEvaluationDetailsQuery, Result<CruiseApplicationEvaluationDetailsDto>>
{
    public Task<Result<CruiseApplicationEvaluationDetailsDto>> Handle(
        GetCruiseApplicationEvaluationDetailsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}