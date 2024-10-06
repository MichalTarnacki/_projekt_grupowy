using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Services.FormsFields;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Services.Factories.FormsB;


public class FormsBFactory(
    IUgUnitsRepository ugUnitsRepository,
    IFormsFieldsService formsFieldsService)
    : IFormsBFactory
{
    public async Task<FormB> Create(FormBDto formBDto, CancellationToken cancellationToken)
    {
        var formB = new FormB { IsCruiseManagerPresent = formBDto.IsCruiseManagerPresent };

        await AddFormBUgUnits(formB, formBDto, cancellationToken);
        await AddFormBGuestUnits(formB, formBDto, cancellationToken);
        await AddCrewMembers(formB, formBDto, cancellationToken);
        await AddFormBShortResearchEquipments(formB, formBDto, cancellationToken);
        
        return formB;
    }


    private async Task AddFormBUgUnits(FormB formB, FormBDto formBDto, CancellationToken cancellationToken)
    {
        foreach (var ugTeamDto in formBDto.UgTeams)
        {
            var ugUnit = await ugUnitsRepository.GetById(ugTeamDto.UgUnitId, cancellationToken);
            if (ugUnit is null)
                continue;

            var formBUgUnit = new FormBUgUnit
            {
                UgUnit = ugUnit,
                NoOfEmployees = ugTeamDto.NoOfEmployees,
                NoOfStudents = ugTeamDto.NoOfStudents
            };
            formB.FormBUgUnits.Add(formBUgUnit);
        }
    }
    
    private async Task AddFormBGuestUnits(FormB formB, FormBDto formBDto, CancellationToken cancellationToken)
    {
        foreach (var guestTeamDto in formBDto.GuestTeams)
        {
            var guestUnit = await formsFieldsService.GetUniqueGuestUnit(guestTeamDto, cancellationToken);
            var formBGuestUnit = new FormBGuestUnit
            {
                GuestUnit = guestUnit,
                NoOfPersons = guestTeamDto.NoOfPersons
            };
            formB.FormBGuestUnits.Add(formBGuestUnit);
        }
    }

    private async Task AddCrewMembers(FormB formB, FormBDto formBDto, CancellationToken cancellationToken)
    {
        foreach (var crewMemberDto in formBDto.CrewMembers)
        {
            var crewMember = await formsFieldsService.GetUniqueCrewMember(crewMemberDto, cancellationToken);
            formB.CrewMembers.Add(crewMember);
        }
    }

    private async Task AddFormBShortResearchEquipments(
        FormB formB, FormBDto formBDto, CancellationToken cancellationToken)
    {
        foreach (var shortResearchEquipmentDto in formBDto.ShortResearchEquipments)
        {
            var researchEquipment = await formsFieldsService
                .GetUniqueResearchEquipment(shortResearchEquipmentDto, cancellationToken);
            var formBShortResearchEquipment = new FormBShortResearchEquipment
            {
                ResearchEquipment = researchEquipment,
                StartDate = shortResearchEquipmentDto.StartDate,
                EndDate = shortResearchEquipmentDto.EndDate
            };
            formB.FormBShortResearchEquipments.Add(formBShortResearchEquipment);
        }
    }
}