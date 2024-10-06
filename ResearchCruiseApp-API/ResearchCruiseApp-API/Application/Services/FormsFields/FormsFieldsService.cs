using AutoMapper;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Models.Interfaces;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Services.FormsFields;


public class FormsFieldsService(
    IMapper mapper,
    IGuestUnitsRepository guestUnitsRepository,
    ICrewMembersRepository crewMembersRepository,
    IResearchEquipmentsRepository researchEquipmentsRepository)
    : IFormsFieldsService
{
    public async Task<GuestUnit> GetUniqueGuestUnit(GuestTeamDto guestTeamDto, CancellationToken cancellationToken)
    {
        var newGuestUnit = mapper.Map<GuestUnit>(guestTeamDto);
        var alreadyPersistedGuestUnit = await guestUnitsRepository.Get(newGuestUnit, cancellationToken);

        return alreadyPersistedGuestUnit ?? newGuestUnit;
    }

    public async Task<CrewMember> GetUniqueCrewMember(CrewMemberDto crewMemberDto, CancellationToken cancellationToken)
    {
        var newCrewMember = mapper.Map<CrewMember>(crewMemberDto);
        var alreadyPersistedCrewMember = await crewMembersRepository.Get(newCrewMember, cancellationToken);

        return alreadyPersistedCrewMember ?? newCrewMember;
    }

    public async Task<ResearchEquipment> GetUniqueResearchEquipment(
        IResearchEquipmentDto researchEquipmentDto, CancellationToken cancellationToken)
    {
        var newResearchEquipment = mapper.Map<ResearchEquipment>(researchEquipmentDto);
        var alreadyPersistedResearchEquipment = await researchEquipmentsRepository
            .Get(newResearchEquipment, cancellationToken);

        return alreadyPersistedResearchEquipment ?? newResearchEquipment;
    }
}