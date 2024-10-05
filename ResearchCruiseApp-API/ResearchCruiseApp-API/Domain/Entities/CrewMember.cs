using System.ComponentModel.DataAnnotations;

namespace ResearchCruiseApp_API.Domain.Entities;


public class CrewMember : Entity
{
    [MaxLength(1024)]
    public string Title { get; init; } = null!;
    
    [MaxLength(1024)]
    public string FirstName { get; init; } = null!;
    
    [MaxLength(1024)]
    public string LastName { get; init; } = null!;
    
    [MaxLength(1024)]
    public string BirthPlace { get; init; } = null!;
    
    [MaxLength(1024)]
    public string BirthDate { get; init; } = null!;
    
    [MaxLength(1024)]
    public string DocumentNumber { get; init; } = null!;
    
    [MaxLength(1024)]
    public string DocumentExpiryDate { get; init; } = null!;
    
    [MaxLength(1024)]
    public string Institution { get; init; } = null!;

    public List<FormB> FormsB { get; set; } = [];
}