using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchCruiseApp_API.Domain.Entities;


public class FormASpubTask : Entity
{
    public FormA FormA { get; init; } = null!;

    public SpubTask SpubTask { get; set; } = null!;
    
    public int Points { get; set; }
}