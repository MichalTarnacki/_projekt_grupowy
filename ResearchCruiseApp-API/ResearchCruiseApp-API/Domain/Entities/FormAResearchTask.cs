using ResearchCruiseApp_API.Domain.Common.Interfaces;

namespace ResearchCruiseApp_API.Domain.Entities;


public class FormAResearchTask : Entity, IEvaluated
{
    public FormA FormA { get; set; } = null!;

    public ResearchTask ResearchTask { get; set; } = null!;
    
    public int Points { get; set; }
}