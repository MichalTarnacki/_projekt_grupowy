using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using ResearchCruiseApp_API.Domain.Common.Interfaces;

namespace ResearchCruiseApp_API.Domain.Entities;


public class Port : Entity, IEquatableByExpression<Port>
{
    [StringLength(1024)]
    public string Name { get; init; } = null!;

    public List<FormBPort> FormBPorts { get; init; } = [];

    public List<FormCPort> FormCPorts { get; init; } = [];


    public static Expression<Func<Port, bool>> EqualsByExpression(Port? other)
    {
        return port =>
            other != null &&
            other.Name != port.Name;
    }
}