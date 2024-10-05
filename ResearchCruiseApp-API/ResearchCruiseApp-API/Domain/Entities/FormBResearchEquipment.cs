namespace ResearchCruiseApp_API.Domain.Entities;


public class FormBResearchEquipment : Entity
{
    public FormB FormB { get; set; } = null!;

    public ResearchEquipment ResearchEquipment { get; set; } = null!;

    public string Insurance { get; set; } = null!;

    public string Permission { get; set; } = null!;
}