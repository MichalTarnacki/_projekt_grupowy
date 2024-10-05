using System.ComponentModel.DataAnnotations;
using ResearchCruiseApp_API.Domain.Common.Enums;

namespace ResearchCruiseApp_API.Domain.Entities;


public class FormBLongResearchEquipment : Entity
{
    public FormB FormB { get; set; } = null!;

    public ResearchEquipment ResearchEquipment { get; set; } = null!;

    public ResearchEquipmentAction Action { get; set; }

    [StringLength(1024)]
    public string Duration { get; set; } = null!;
}