﻿using AutoMapper;
using Microsoft.AspNetCore.SignalR.Protocol;
using ResearchCruiseApp_API.Application.Common.Models.DTOs;
using ResearchCruiseApp_API.Application.ExternalServices;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Models.DTOs.Forms;
using ResearchCruiseApp_API.Application.Services.Factories.ContractDtos;
using ResearchCruiseApp_API.Application.Services.Factories.FormUserDtos;
using ResearchCruiseApp_API.Application.UseCases.CruiseApplications.GetAllCruiseApplications;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Services.Factories.FormAInitValuesDtosFactory;


public class FormAInitValuesDtosFactory(
    IIdentityService identityService,
    IFormUserDtosFactory formUserDtosFactory,
    IContractDtosFactory contractDtosFactory,
    IResearchAreasRepository researchAreasRepository,
    IUgUnitsRepository ugUnitsRepository,
    ICruiseApplicationsRepository cruiseApplicationsRepository,
    ICurrentUserService currentUserService,
    IMapper mapper)
    : IFormAInitValuesDtosFactory
{
    public async Task<FormAInitValuesDto> Create(CancellationToken cancellationToken)
    {
        var allUserDtos = await identityService.GetAllUsersDtos(cancellationToken);
        var cruiseApplications = await GetAllCruiseApplicationsForUser(cancellationToken);
        
        var result = new FormAInitValuesDto
        {
            CruiseManagers = GetCruiseManagers(allUserDtos),
            DeputyManagers = GetDeputyManagers(allUserDtos),
            Years = GetYears(),
            ShipUsages = GetShipUsages(),
            ResearchAreas = await GetResearchAreas(cancellationToken),
            CruiseGoals = GetCruiseGoals(),
            HistoricalResearchTasks = GetHistoricalResearchTasks(cruiseApplications),
            HistoricalContracts = await GetHistoricalContracts(cruiseApplications),
            UgUnits = await GetUgUnits(cancellationToken),
            HistoricalGuestInstitutions = GetHistoricalInstitutions(cruiseApplications),
            HistoricalSpubTasks = GetHistoricalSpubTasks(cruiseApplications)
        };

        return result;
    }


    private async Task<List<CruiseApplication>> GetAllCruiseApplicationsForUser(CancellationToken cancellationToken)
    {
        var userId = currentUserService.GetId();
        var cruiseApplications = userId is null
            ? []
            : await cruiseApplicationsRepository
                .GetAllByUserIdWithFormA(userId.Value, cancellationToken);

        return cruiseApplications;
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

    private List<ResearchTaskDto> GetHistoricalResearchTasks(IEnumerable<CruiseApplication> cruiseApplications)
    {
        return cruiseApplications
            .SelectMany(cruiseApplication =>
                cruiseApplication.FormA?.FormAResearchTasks.Select(formAResearchTask => formAResearchTask.ResearchTask)
                ?? [])
            .Distinct()
            .Select(mapper.Map<ResearchTaskDto>)
            .ToList();
    }

    private async Task<List<UgUnitDto>> GetUgUnits(CancellationToken cancellationToken)
    {
        return (await ugUnitsRepository
                .GetAll(cancellationToken))
            .Select(mapper.Map<UgUnitDto>)
            .ToList();
    }

    private async Task<List<ContractDto>> GetHistoricalContracts(IEnumerable<CruiseApplication> cruiseApplications)
    {
        var historicalContractDtosTasks = cruiseApplications
            .SelectMany(cruiseApplication =>
                cruiseApplication.FormA?.FormAContracts.Select(formAContract => formAContract.Contract)
                ?? [])
            .Distinct()
            .Select(contractDtosFactory.Create);

        var historicalTasks = (await Task.WhenAll(historicalContractDtosTasks))
            .ToList();

        return historicalTasks;
    }

    private static List<string> GetHistoricalInstitutions(IEnumerable<CruiseApplication> cruiseApplications)
    {
        var historicalGuestTeams = cruiseApplications
            .SelectMany(cruiseApplication =>
                cruiseApplication.FormA?.FormAGuestUnits.Select(formAGuestUnit => formAGuestUnit.GuestUnit.Name)
                ?? [])
            .Distinct()
            .ToList();

        return historicalGuestTeams;
    }

    private List<SpubTaskDto> GetHistoricalSpubTasks(IEnumerable<CruiseApplication> cruiseApplications)
    {
        return cruiseApplications
            .SelectMany(cruiseApplication =>
                cruiseApplication.FormA?.FormASpubTasks.Select(formASpubTask => formASpubTask.SpubTask)
                ?? [])
            .Distinct()
            .Select(mapper.Map<SpubTaskDto>)
            .ToList();
    }
}