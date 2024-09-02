﻿using AutoMapper;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.SharedServices.Factories.Contracts;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.SharedServices.Factories.FormsA;


internal class FormsAFactory(
    IResearchTasksRepository researchTasksRepository,
    IUgUnitsRepository ugUnitsRepository,
    IGuestUnitsRepository guestUnitsRepository,
    IPublicationsRepository publicationsRepository,
    ISpubTasksRepository spubTasksRepository,
    IMapper mapper,
    IContractsFactory contractsFactory)
    : IFormsAFactory
{
    public async Task<FormA> Create(FormADto formADto, CancellationToken cancellationToken)
    {
        var formA = mapper.Map<FormA>(formADto);

        await AddFormAResearchTasks(formA, formADto, cancellationToken);
        await AddContracts(formA, formADto);
        await AddFormAUgUnits(formA, formADto, cancellationToken);
        await AddFormAGuestUnits(formA, formADto, cancellationToken);
        await AddFormAPublications(formA, formADto, cancellationToken);
        await AddFormASpubTasks(formA, formADto, cancellationToken);

        return formA;
    }


    private async Task AddFormAResearchTasks(FormA formA, FormADto formADto, CancellationToken cancellationToken)
    {
        var allResearchTasks = await researchTasksRepository.GetAll(cancellationToken);
        
        foreach (var researchTaskDto in formADto.ResearchTasks)
        {
            var researchTask = GetUniqueResearchTask(researchTaskDto, allResearchTasks);
            var formAResearchTask = new FormAResearchTask();

            formA.FormAResearchTasks.Add(formAResearchTask);
            researchTask.FormAResearchTasks.Add(formAResearchTask);
        }
    }
    
    private async Task AddContracts(FormA formA, FormADto formADto)
    {
        foreach (var contractDto in formADto.Contracts)
        {
            formA.Contracts.Add(await contractsFactory.Create(contractDto));
        }
    }

    private async Task AddFormAUgUnits(FormA formA, FormADto formADto, CancellationToken cancellationToken)
    {
        foreach (var ugUnitDto in formADto.UgTeams)
        {
            var ugUnit = await ugUnitsRepository.GetById(ugUnitDto.UgUnitId, cancellationToken);
            if (ugUnit is null)
                continue;

            var formAUgUnit = new FormAUgUnit
            {
                NoOfEmployees = ugUnitDto.NoOfEmployees,
                NoOfStudents = ugUnitDto.NoOfStudents
            };
            
            formA.FormAUgUnits.Add(formAUgUnit);
            ugUnit.FormAUgUnits.Add(formAUgUnit);
        }
    }

    private async Task AddFormAGuestUnits(FormA formA, FormADto formADto, CancellationToken cancellationToken)
    {
        var allGuestUnits = await guestUnitsRepository.GetAll(cancellationToken);

        foreach (var guestUnitDto in formADto.GuestTeams)
        {
            var guestUnit = GetUniqueGuestUnit(guestUnitDto, allGuestUnits);
            var formAGuestUnit = new FormAGuestUnit
            {
                NoOfPersons = guestUnitDto.NoOfPersons
            };
            
            formA.FormAGuestUnits.Add(formAGuestUnit);
            guestUnit.FormAGuestUnits.Add(formAGuestUnit);
        }
    }

    private async Task AddFormAPublications(FormA formA, FormADto formADto, CancellationToken cancellationToken)
    {
        var allPublications = await publicationsRepository.GetAll(cancellationToken);

        foreach (var publicationDto in formADto.Publications)
        {
            var publication = GetUniquePublication(publicationDto, allPublications);
            var formAPublication = new FormAPublication();

            formA.FormAPublications.Add(formAPublication);
            publication.FormAPublications.Add(formAPublication);
        }
    }

    private async Task AddFormASpubTasks(FormA formA, FormADto formADto, CancellationToken cancellationToken)
    {
        var allSpubTasks = await spubTasksRepository.GetAll(cancellationToken);

        foreach (var spubTaskDto in formADto.SpubTasks)
        {
            var spubTask = GetUniqueSpubTask(spubTaskDto, allSpubTasks);
            var formASpubTask = new FormASpubTask();
            
            formA.FormASpubTasks.Add(formASpubTask);
            spubTask.FormASpubTasks.Add(formASpubTask);
        }
    }
    
    private ResearchTask GetUniqueResearchTask(ResearchTaskDto researchTaskDto, List<ResearchTask> allResearchTasks)
    {
        var researchTask = mapper.Map<ResearchTask>(researchTaskDto);
        var alreadyPersistedResearchTask = allResearchTasks
            .Find(r => r.Equals(researchTask));

        if (alreadyPersistedResearchTask is not null)
            researchTask = alreadyPersistedResearchTask;
        else
            allResearchTasks.Add(researchTask);

        return researchTask;
    }
    
    private GuestUnit GetUniqueGuestUnit(GuestUnitDto guestUnitDto, List<GuestUnit> allGuestUnits)
    {
        var guestUnit = mapper.Map<GuestUnit>(guestUnitDto);
        var alreadyPersistedGuestUnit = allGuestUnits
            .Find(gu => gu.Equals(guestUnit));

        if (alreadyPersistedGuestUnit is not null)
            guestUnit = alreadyPersistedGuestUnit;
        else
            allGuestUnits.Add(guestUnit);

        return guestUnit;
    }
    
    private Publication GetUniquePublication(PublicationDto publicationDto, List<Publication> allPublications)
    {
        var publication = mapper.Map<Publication>(publicationDto);
        var alreadyPersistedPublication = allPublications
            .Find(p => p.Equals(publication));

        if (alreadyPersistedPublication is not null)
            publication = alreadyPersistedPublication;
        else
            allPublications.Add(publication);

        return publication;
    }
    
    private SpubTask GetUniqueSpubTask(SpubTaskDto spubTaskDto, List<SpubTask> allSpubTasks)
    {
        var spubTask = mapper.Map<SpubTask>(spubTaskDto);
        var alreadyPersistedSpubTask = allSpubTasks
            .Find(st => st.Equals(spubTask));

        if (alreadyPersistedSpubTask is not null)
            spubTask = alreadyPersistedSpubTask;
        else
            allSpubTasks.Add(spubTask);

        return spubTask;
    }
}