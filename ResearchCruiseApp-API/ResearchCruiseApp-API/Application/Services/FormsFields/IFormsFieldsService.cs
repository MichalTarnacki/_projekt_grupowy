using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Models.Interfaces;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Services.FormsFields;


public interface IFormsFieldsService
{
    Task<GuestUnit> GetUniqueGuestUnit(GuestTeamDto guestTeamDto, CancellationToken cancellationToken);
    Task<CrewMember> GetUniqueCrewMember(CrewMemberDto crewMemberDto, CancellationToken cancellationToken);
    Task<ResearchEquipment> GetUniqueResearchEquipment(
        IResearchEquipmentDto researchEquipmentDto, CancellationToken cancellationToken);
}