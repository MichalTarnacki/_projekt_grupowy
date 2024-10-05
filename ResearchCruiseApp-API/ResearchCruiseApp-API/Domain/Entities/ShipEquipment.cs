using System.ComponentModel.DataAnnotations;
using ResearchCruiseApp_API.Domain.Common.Interfaces;

namespace ResearchCruiseApp_API.Domain.Entities;


public class ShipEquipment : Entity, IDbDictionary
{
    [StringLength(1024)]
    public string Name { get; set; } = null!;
    
    public bool IsActive { get; set; }
}