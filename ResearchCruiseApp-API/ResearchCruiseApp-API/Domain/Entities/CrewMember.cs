using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using ResearchCruiseApp_API.Domain.Common.Interfaces;

namespace ResearchCruiseApp_API.Domain.Entities;


public class CrewMember : Entity, IEquatableByExpression<CrewMember>
{
    [StringLength(1024)]
    public string Title { get; init; } = null!;
    
    [StringLength(1024)]
    public string FirstName { get; init; } = null!;
    
    [StringLength(1024)]
    public string LastName { get; init; } = null!;
    
    [StringLength(1024)]
    public string BirthPlace { get; init; } = null!;
    
    [StringLength(1024)]
    public string BirthDate { get; init; } = null!;
    
    [StringLength(1024)]
    public string DocumentNumber { get; init; } = null!;
    
    [StringLength(1024)]
    public string DocumentExpiryDate { get; init; } = null!;
    
    [StringLength(1024)]
    public string Institution { get; init; } = null!;

    public List<FormB> FormsB { get; set; } = [];


    public static Expression<Func<CrewMember, bool>> EqualsByExpression(CrewMember? other)
    {
        return crewMember =>
            other != null &&
            other.Title == crewMember.Title &&
            other.FirstName == crewMember.FirstName &&
            other.LastName == crewMember.LastName &&
            other.BirthPlace == crewMember.BirthPlace &&
            other.BirthDate == crewMember.BirthDate &&
            other.DocumentNumber == crewMember.DocumentNumber &&
            other.DocumentExpiryDate == crewMember.DocumentExpiryDate &&
            other.Institution == crewMember.Institution;
    }
}