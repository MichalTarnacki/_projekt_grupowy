using System.ComponentModel.DataAnnotations;

namespace ResearchCruiseApp_API.Domain.Entities;


public class ResearchTaskEffect : Entity
{
    public FormC FormC { get; init; } = null!;

    public ResearchTask ResearchTask { get; init; } = null!;

    [StringLength(1024)]
    public string Done { get; set; } = null!;

    [StringLength(1024)]
    public string? PublicationMinisterialPoints { get; set; }
    
    [StringLength(1024)]
    public string ManagerConditionMet { get; init; } = null!;
    
    [StringLength(1024)]
    public string DeputyConditionMet { get; init; } = null!;
    
    public List<UserEffect> UserEffects { get; set; } = [];
}