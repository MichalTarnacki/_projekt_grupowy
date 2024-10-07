using System.ComponentModel.DataAnnotations;

namespace ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;


public class ShipEquipmentDto
{
    [StringLength(1024)]
    public Guid Id { get; init; }
}