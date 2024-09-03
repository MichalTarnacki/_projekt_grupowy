namespace ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;


public class FormAPublicationDto
{
    public Guid Id { get; init; }

    public PublicationDto Publication { get; init; } = null!;
    
    public int Points { get; init; }
}