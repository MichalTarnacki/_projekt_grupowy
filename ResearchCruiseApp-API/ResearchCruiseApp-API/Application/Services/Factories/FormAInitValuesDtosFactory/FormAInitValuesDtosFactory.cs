using AutoMapper;
using ResearchCruiseApp_API.Application.Common.Models.DTOs;
using ResearchCruiseApp_API.Application.ExternalServices;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Models.DTOs.Forms;
using ResearchCruiseApp_API.Application.Services.Factories.FormUserDtos;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Services.Factories.FormAInitValuesDtosFactory;


public class FormAInitValuesDtosFactory(
    IIdentityService identityService,
    IFormUserDtosFactory formUserDtosFactory,
    IResearchAreasRepository researchAreasRepository,
    IUgUnitsRepository ugUnitsRepository,
    IResearchTasksRepository researchTasksRepository,
    ICruiseApplicationsRepository cruiseApplicationsRepository,
    ICurrentUserService currentUserService,
    IMapper mapper)
    : IFormAInitValuesDtosFactory
{
    public async Task<FormAInitValuesDto> Create(CancellationToken cancellationToken)
    {
        var allUserDtos = await identityService.GetAllUsersDtos(cancellationToken);
        
        var ugUnits = (await ugUnitsRepository
                .GetAll(cancellationToken))
            .Select(mapper.Map<UgUnitDto>)
            .ToList();
        
        var result = new FormAInitValuesDto
        {
            CruiseManagers = GetCruiseManagers(allUserDtos),
            DeputyManagers = GetDeputyManagers(allUserDtos),
            Years = GetYears(),
            ShipUsages = GetShipUsages(),
            ResearchAreas = await GetResearchAreas(cancellationToken),
            CruiseGoals = GetCruiseGoals(),
            HistoricalResearchTasks = await GetHistoricalResearchTasks(cancellationToken),
            UgUnits = ugUnits
        };

        return result;
    }


    private List<FormUserDto> GetCruiseManagers(IEnumerable<UserDto> allUserDtos)
    {
        return allUserDtos
            .Select(formUserDtosFactory.Create)
            .ToList();
    }
    
    private List<FormUserDto> GetDeputyManagers(IEnumerable<UserDto> allUserDtos)
    {
        return allUserDtos
            .Select(formUserDtosFactory.Create)
            .ToList();
    }

    private static List<string> GetYears()
    {
        return
        [
            DateTime.Now.Year.ToString(),
            (DateTime.Now.Year + 1).ToString()
        ];
    }

    private static List<string> GetShipUsages()
    {
        return
        [
            "całą dobę",
            "jedynie w ciągu dnia (maks. 8–12 h)",
            "jedynie w nocy (maks. 8–12 h)",
            "8–12 h w ciągu doby rejsowej, ale bez znaczenia o jakiej porze albo z założenia" +
            "o różnych porach",

            "w inny sposób"
        ];
    }

    private async Task<List<ResearchAreaDto>> GetResearchAreas(CancellationToken cancellationToken)
    {
        return (await researchAreasRepository
                .GetAll(cancellationToken))
            .Select(mapper.Map<ResearchAreaDto>)
            .ToList();
    }

    private static List<string> GetCruiseGoals()
    {
        return
        [
            "Naukowy",
            "Komercyjny",
            "Dydaktyczny"
        ];
    }

    private async Task<List<ResearchTaskDto>> GetHistoricalResearchTasks(CancellationToken cancellationToken)
    {
        var userId = currentUserService.GetId();
        if (userId is null)
            return [];

        var cruiseApplications = await cruiseApplicationsRepository
            .GetAllByUserIdWithFormA(userId.GetValueOrDefault(), cancellationToken);

        var historicalTasks = cruiseApplications
            .SelectMany(cruiseApplication =>
                cruiseApplication.FormA?.FormAResearchTasks.Select(formAResearchTask => formAResearchTask.ResearchTask)
                ?? [])
            .Distinct()
            .Select(mapper.Map<ResearchTaskDto>)
            .ToList();

        return historicalTasks;
    }
}