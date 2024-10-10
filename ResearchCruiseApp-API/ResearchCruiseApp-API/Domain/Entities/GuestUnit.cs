using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using ResearchCruiseApp_API.Domain.Common.Interfaces;

namespace ResearchCruiseApp_API.Domain.Entities;


public class GuestUnit : Entity, IEquatableByExpression<GuestUnit>
{
    [StringLength(1024)]
    public string Name { get; init; } = null!;

    public List<FormAGuestUnit> FormAGuestUnits { get; init; } = [];

    public List<FormBGuestUnit> FormBGuestUnits { get; init; } = [];
    
    public List<FormCGuestUnit> FormCGuestUnits { get; init; } = [];
    
    
    public static Expression<Func<GuestUnit, bool>> EqualsByExpression(GuestUnit? other)
    {
        return guestUnit =>
            other != null &&
            other.Name == guestUnit.Name;
    }
}