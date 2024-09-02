using System.ComponentModel.DataAnnotations;

namespace ResearchCruiseApp_API.Domain.Entities;


public class FormA : Entity
{
    public Guid CruiseManagerId { get; set; }

    public Guid DeputyManagerId { get; set; }
    
    public int Year { get; set; }
  
    public int AcceptablePeriodBeg { get; set; }
    
    public int AcceptablePeriodEnd { get; set; }
    
    public int OptimalPeriodBeg { get; set; }
    
    public int OptimalPeriodEnd { get; set; }
    
    public int CruiseHours { get; set; }

    [StringLength(1024)]
    public string? PeriodNotes { get; set; }
    
    public int ShipUsage { get; set; }

    [StringLength(1024)]
    public string? DifferentUsage { get; set; }

    public List<Permission> Permissions { get; set; } = [];
    
    public int ResearchArea { get; set; } 
    
    [MaxLength(1024)]
    public string? ResearchAreaInfo { get; set; }
    
    public int CruiseGoal { get; set; }
    
    [MaxLength(1024)]
    public string? CruiseGoalDescription { get; set; }

    public List<FormAResearchTask> FormAResearchTasks { get; set; } = [];

    public List<Contract> Contracts { get; set; } = [];

    public List<FormAUgUnit> FormAUgUnits { get; set; } = [];

    public int UgUnitsPoints { get; set; }
    
    public List<FormAGuestUnit> FormAGuestUnits { get; set; } = [];

    public List<FormAPublication> FormAPublications { get; set; } = [];
    
    public List<FormASpubTask> FormASpubTasks { get; set; } = [];
}