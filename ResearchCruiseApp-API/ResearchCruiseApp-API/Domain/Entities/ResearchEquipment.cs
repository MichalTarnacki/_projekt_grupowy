using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using ResearchCruiseApp_API.Domain.Common.Interfaces;

namespace ResearchCruiseApp_API.Domain.Entities;


public class ResearchEquipment : Entity, IEquatableByExpression<ResearchEquipment>
{
    [StringLength(1024)]
    public string Name { get; init; } = null!;

    public List<FormBShortResearchEquipment> FormBShortResearchEquipments { get; init; } = [];

    public List<FormBLongResearchEquipment> FormBLongResearchEquipments { get; init; } = [];

    public List<FormBResearchEquipment> FormBResearchEquipments { get; init; } = [];

    public List<FormCShortResearchEquipment> FormCShortResearchEquipments { get; init; } = [];

    public List<FormCLongResearchEquipment> FormCLongResearchEquipments { get; init; } = [];

    public List<FormCResearchEquipment> FormCResearchEquipments { get; init; } = [];


    public static Expression<Func<ResearchEquipment, bool>> EqualsByExpression(ResearchEquipment? other)
    {
        return researchEquipment =>
            other != null &&
            researchEquipment.Name == other.Name;
    }
}