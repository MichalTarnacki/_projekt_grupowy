namespace ResearchCruiseApp_API.Application.Models.DTOs.Cruises;


public class CruiseFormDto
{
    public string StartDate { get; set; } = null!;

    public string EndDate { get; set; } = null!;

    public CruiseManagersTeamDto ManagersTeam { get; set; }
    
    public List<Guid> CruiseApplicationsIds { get; set; } = [];
}