using AutoMapper;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Services.FormsFields;
using ResearchCruiseApp_API.Domain.Common.Enums;
using ResearchCruiseApp_API.Domain.Common.Extensions;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Services.Factories.FormsB;


public class FormsBFactory(
    Mapper mapper,
    IUgUnitsRepository ugUnitsRepository,
    IShipEquipmentsRepository shipEquipmentsRepository,
    IFormsFieldsService formsFieldsService)
    : IFormsBFactory
{
    public async Task<FormB> Create(FormBDto formBDto, CancellationToken cancellationToken)
    {
        var formB = mapper.Map<FormB>(formBDto);

        await AddFormBUgUnits(formB, formBDto, cancellationToken);
        await AddFormBGuestUnits(formB, formBDto, cancellationToken);
        await AddCrewMembers(formB, formBDto, cancellationToken);
        await AddFormBShortResearchEquipments(formB, formBDto, cancellationToken);
        await AddFormBLongResearchEquipments(formB, formBDto, cancellationToken);
        await AddFormBPorts(formB, formBDto, cancellationToken);
        await AddCruiseDaysDetails(formB, formBDto, cancellationToken);
        await AddFormBResearchEquipments(formB, formBDto, cancellationToken);
        await AddShipEquipments(formB, formBDto, cancellationToken);
        
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

    private async Task AddFormBLongResearchEquipments(
        FormB formB, FormBDto formBDto, CancellationToken cancellationToken)
    {
        foreach (var longResearchEquipmentDto in formBDto.LongResearchEquipments)
        {
            var researchEquipment = await formsFieldsService
                .GetUniqueResearchEquipment(longResearchEquipmentDto, cancellationToken);
            var formBLongResearchEquipment = new FormBLongResearchEquipment
            {
                ResearchEquipment = researchEquipment,
                Action = longResearchEquipmentDto.Action.ToEnum<ResearchEquipmentAction>(),
                Duration = longResearchEquipmentDto.Duration
            };
            formB.FormBLongResearchEquipments.Add(formBLongResearchEquipment);
        }
    }

    private async Task AddFormBPorts(FormB formB, FormBDto formBDto, CancellationToken cancellationToken)
    {
        foreach (var portDto in formBDto.Ports)
        {
            var port = await formsFieldsService.GetUniquePort(portDto, cancellationToken);
            var formBPort = new FormBPort
            {
                Port = port,
                StartTime = portDto.StartTime,
                EndTime = portDto.EndTime
            };
            formB.FormBPorts.Add(formBPort);
        }
    }

    private async Task AddCruiseDaysDetails(FormB formB, FormBDto formBDto, CancellationToken cancellationToken)
    {
        foreach (var cruiseDayDetailsDto in formBDto.CruiseDaysDetails)
        {
            var cruiseDayDetails = await formsFieldsService
                .GetUniqueCruiseDayDetails(cruiseDayDetailsDto, cancellationToken);
            formB.CruiseDaysDetails.Add(cruiseDayDetails);
        }
    }
    
    private async Task AddFormBResearchEquipments(FormB formB, FormBDto formBDto, CancellationToken cancellationToken)
    {
        foreach (var researchEquipmentDto in formBDto.ResearchEquipments)
        {
            var researchEquipment = await formsFieldsService
                .GetUniqueResearchEquipment(researchEquipmentDto, cancellationToken);
            var formBResearchEquipment = new FormBResearchEquipment
            {
                ResearchEquipment = researchEquipment,
                Insurance = researchEquipmentDto.Insurance,
                Permission = researchEquipmentDto.Permission
            };
            formB.FormBResearchEquipments.Add(formBResearchEquipment);
        }
    }

    private async Task AddShipEquipments(FormB formB, FormBDto formBDto, CancellationToken cancellationToken)
    {
        foreach (var shipEquipmentDto in formBDto.ShipEquipments)
        {
            var shipEquipment = await shipEquipmentsRepository.GetById(shipEquipmentDto.Id, cancellationToken);
            if (shipEquipment is null)
                continue;
            
            formB.ShipEquipments.Add(shipEquipment);
        }
    }
}