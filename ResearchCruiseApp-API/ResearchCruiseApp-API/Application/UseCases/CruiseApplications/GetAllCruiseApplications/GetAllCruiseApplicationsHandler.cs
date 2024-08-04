using AutoMapper;
using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.ServicesInterfaces.Persistence.Repositories;
using ResearchCruiseApp_API.Infrastructure.Persistence;

namespace ResearchCruiseApp_API.Application.UseCases.CruiseApplications.GetAllCruiseApplications;


public class GetAllCruiseApplicationsHandler(
    IMapper mapper,
    ICruiseApplicationsRepository cruiseApplicationsRepository) 
    : IRequestHandler<GetAllCruiseApplicationsQuery, Result<List<CruiseApplicationDto>>>
{
    public async Task<Result<List<CruiseApplicationDto>>> Handle(
        GetAllCruiseApplicationsQuery request,
        CancellationToken cancellationToken)
    {
        var cruiseApplications =
            await cruiseApplicationsRepository.GetAllCruiseApplications(cancellationToken);
            
        var cruiseApplicationDtos = cruiseApplications
            .Select(mapper.Map<CruiseApplicationDto>)
            .ToList();

        return cruiseApplicationDtos;
    }
}