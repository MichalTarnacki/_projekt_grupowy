﻿using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Models.Interfaces;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Services.FormsFieldsService;


public interface IFormsFieldsService
{
    Task<Permission> GetUniquePermission(
        PermissionDto permissionDto,
        IEnumerable<Permission> permissionsInMemory,
        CancellationToken cancellationToken);
    
    Task<ResearchTask> GetUniqueResearchTask(
        IResearchTaskDto researchTaskDto,
        IEnumerable<ResearchTask> researchTasksInMemory,
        CancellationToken cancellationToken);
    
    Task<GuestUnit> GetUniqueGuestUnit(
        GuestTeamDto guestTeamDto, IEnumerable<GuestUnit> guestUnitsInMemory, CancellationToken cancellationToken);

    Task<Contract> GetUniqueContract(
        ContractDto contractDto, IEnumerable<Contract> contractsInMemory, CancellationToken cancellationToken);

    Task<Publication> GetUniquePublication(
        PublicationDto publicationDto,
        IEnumerable<Publication> publicationInMemory,
        CancellationToken cancellationToken);
    
    Task<SpubTask> GetUniqueSpubTask(
        SpubTaskDto spubTaskDto, IEnumerable<SpubTask> spubTasksInMemory, CancellationToken cancellationToken);
    
    Task<CrewMember> GetUniqueCrewMember(
        CrewMemberDto crewMemberDto, IEnumerable<CrewMember> crewMembersInMemory, CancellationToken cancellationToken);
    
    Task<ResearchEquipment> GetUniqueResearchEquipment(
        IResearchEquipmentDto researchEquipmentDto,
        IEnumerable<ResearchEquipment> researchEquipmentsInMemory,
        CancellationToken cancellationToken);
    
    Task<Port> GetUniquePort(PortDto portDto, IEnumerable<Port> portsInMemory, CancellationToken cancellationToken);
    
    Task<CruiseDayDetails> GetUniqueCruiseDayDetails(
        CruiseDayDetailsDto cruiseDayDetailsDto,
        IEnumerable<CruiseDayDetails> cruiseDayDetailsInMemory,
        CancellationToken cancellationToken);
}