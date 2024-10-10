using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using ResearchCruiseApp_API.Domain.Common.Interfaces;

namespace ResearchCruiseApp_API.Domain.Entities;


public class CruiseDayDetails : Entity, IEquatableByExpression<CruiseDayDetails>
{
    [StringLength(1024)]
    public string Number { get; init; } = null!;

    [StringLength(1024)]
    public string Hours { get; init; } = null!;
    
    [StringLength(1024)]
    public string TaskName { get; init; } = null!;

    [StringLength(1024)]
    public string Region { get; init; } = null!;

    [StringLength(1024)]
    public string Position { get; init; } = null!;

    [StringLength(1024)]
    public string Comment { get; init; } = null!;

    public List<FormB> FormsB { get; init; } = [];
    
    public List<FormC> FormsC { get; init; } = [];


    public static Expression<Func<CruiseDayDetails, bool>> EqualsByExpression(CruiseDayDetails? other)
    {
        return cruiseDayDetails =>
            other != null &&
            other.Number == cruiseDayDetails.Number &&
            other.Hours == cruiseDayDetails.Hours &&
            other.TaskName == cruiseDayDetails.TaskName &&
            other.Region == cruiseDayDetails.Region &&
            other.Position == cruiseDayDetails.Position &&
            other.Comment == cruiseDayDetails.Comment;
    }
}