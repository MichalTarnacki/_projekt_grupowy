namespace ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;


public class FormAContractDto
{
    public Guid Id { get; init; }

    public ContractDto Contract { get; init; } = null!;
    
    public int Points { get; init; }
}