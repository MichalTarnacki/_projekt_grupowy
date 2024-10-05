namespace ResearchCruiseApp_API.Domain.Entities;


public class FormBShortResearchEquipment : Entity
{
    public FormB FormB { get; set; } = null!;
    
    public ResearchEquipment ResearchEquipment { get; set; } = null!;

    public string StartDate { get; set; } = null!;

    public string EndDate { get; set; } = null!;
}