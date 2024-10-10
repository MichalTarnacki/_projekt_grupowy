using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using ResearchCruiseApp_API.Domain.Common.Interfaces;

namespace ResearchCruiseApp_API.Domain.Entities;


public class SpubTask : Entity, IEquatableByExpression<SpubTask>
{
    [StringLength(1024)]
    public string Name { get; init; } = null!;
    
    [StringLength(1024)]
    public string YearFrom { get; init; } = null!;

    [StringLength(1024)]
    public string YearTo { get; init; } = null!;
    
    public List<FormASpubTask> FormASpubTasks { get; init; } = [];
    
    public List<FormCSpubTask> FormCSpubTasks { get; init; } = [];


    public static Expression<Func<SpubTask, bool>> EqualsByExpression(SpubTask? other)
    {
        return spubTask =>
            other != null &&
            other.Name == spubTask.Name &&
            other.YearFrom == spubTask.YearFrom &&
            other.YearTo == spubTask.YearTo;
    }
}