﻿using System.ComponentModel.DataAnnotations;

namespace ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;


public class FormCDto
{
    [StringLength(1)]
    public string ShipUsage { get; init; } = null!;
    
    public List<PermissionDto> Permissions { get; init; } = [];
    
    public Guid ResearchAreaId { get; init; }
    
    public List<UgTeamDto> UgTeams { get; init; } = [];

    public List<GuestTeamDto> GuestTeams { get; init; } = [];

    public List<ResearchTaskEffectDto> ResearchTasksEffects { get; init; } = [];
    
    public List<ContractDto> Contracts { get; init; } = [];
    
    public List<SpubTaskDto> SpubTasks { get; init; } = [];
    
    public List<ShortResearchEquipmentDto> ShortResearchEquipments { get; init; } = [];
    
    public List<LongResearchEquipmentDto> LongResearchEquipments { get; init; } = [];
    
    public List<PortDto> Ports { get; init; } = [];
    
    public List<CruiseDayDetailsDto> CruiseDaysDetails { get; init; } = [];
    
    public List<ResearchEquipmentDto> ResearchEquipments { get; init; } = [];
    
    public List<Guid> ShipEquipmentsIds { get; init; } = [];

    public List<CollectedSampleDto> CollectedSamples { get; init; } = [];
    
    [StringLength(1024)]
    public string? SpubReportData { get; init; } = null!;
    
    [StringLength(1024)]
    public string? AdditionalDescription { get; init; } = null!;

    public List<FileDto> Photos { get; init; } = []!;
}