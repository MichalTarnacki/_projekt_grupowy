using System.ComponentModel.DataAnnotations;

namespace ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;


public class FormBDto
{
    [StringLength(1024)]
    public string IsCruiseManagerPresent { get; init; } = null!;

    public List<PermissionDto> Permissions { get; init; } = [];

    public List<UgTeamDto> UgTeams { get; init; } = [];

    public List<GuestTeamDto> GuestTeams { get; init; } = [];
    
    //(?) opcjonalnie opis. 
    [Range(0,20)]
    public int? ResearchArea { get; set; }
    
    
    //Cel rejsu (opis max. 100 słów):
    public int? CruiseGoal { get; set; }
    
    [MaxLength(200)]
    public string? CruiseGoalDescription { get; set; }

    
    //Zadania
    public List<ResearchTaskDto>? ResearchTasks { get; set; }

    
    //Lista umów
    public List<ContractDto>? Contracts { get; set; }
    
    //Publikacje i Prace
    public List<PublicationDto>? Publications { get; set; }
    
    
    //Zadania SPUB
    public List<SpubTaskDto> SpubTasks { get; set; } = [];
}