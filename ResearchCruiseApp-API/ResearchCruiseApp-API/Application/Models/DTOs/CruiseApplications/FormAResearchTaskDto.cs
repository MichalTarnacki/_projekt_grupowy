namespace ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;


public class FormAResearchTaskDto
{
    public Guid Id { get; init; }
    
    public ResearchTaskDto ResearchTask { get; init; } = null!;
    
    public int Points { get; init; }
}