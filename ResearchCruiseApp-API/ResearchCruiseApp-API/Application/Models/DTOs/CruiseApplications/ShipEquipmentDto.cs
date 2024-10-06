using System.ComponentModel.DataAnnotations;

namespace ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;


public class ShipEquipmentDto
{
    [StringLength(1024)]
    public string Name { get; init; } = null!;
}