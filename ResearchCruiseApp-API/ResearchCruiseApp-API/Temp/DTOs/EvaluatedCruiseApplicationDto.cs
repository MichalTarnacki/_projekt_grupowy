using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;

namespace ResearchCruiseApp_API.Temp.DTOs;


public class EvaluatedCruiseApplicationDto
{
    public List<EvaluatedResearchTaskDto> ResearchTasks { get; set; } = [];
    
    public List<EvaluatedContractDto> Contracts { get; set; }  = [];
    
    public List<UgUnitDto> UgTeams { get; set; } = [];
    public int UgTeamsPoints { get; set; }

    public List<GuestUnitDto> GuestTeams { get; set; } = [];

    public List<EvaluatedPublicationDto> Publications { get; set; } = [];

    public List<EvaluatedResearchTaskDto> CruiseEffects { get; set; } = [];

    public List<EvaluatedSpubTaskDto> SpubTasks { get; set; } = [];
}