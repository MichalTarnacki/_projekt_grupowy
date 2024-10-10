using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using ResearchCruiseApp_API.Domain.Common.Enums;
using ResearchCruiseApp_API.Domain.Common.Interfaces;

namespace  ResearchCruiseApp_API.Domain.Entities;


public class ResearchTask : Entity, IEquatableByExpression<ResearchTask>
{
    public ResearchTaskType Type { get; init; }

    [StringLength(1024)]
    public string? Title { get; init; }
    
    [StringLength(1024)]
    public string? Author { get; init; }
    
    [StringLength(1024)]
    public string? Institution { get; init; }

    [StringLength(1024)]
    public string? Date { get; init; }
    
    [StringLength(1024)]
    public string? StartDate { get; init; }
    
    [StringLength(1024)]
    public string? EndDate { get; init; }
    
    [StringLength(1024)]
    public string? FinancingAmount { get; init; }
    
    [StringLength(1024)]
    public string? Description { get; init; }

    [StringLength(1024)]
    public string? FinancingApproved { get; init; } = "false";

    [StringLength(1024)]
    public string? SecuredAmount { get; set; }

    [StringLength(1024)]
    public string? MinisterialPoints { get; set; }
    
    public List<FormAResearchTask> FormAResearchTasks { get; set; } = [];
    
    public List<FormCResearchTask> FormCResearchTasks { get; set; } = [];


    public static Expression<Func<ResearchTask, bool>> EqualsByExpression(ResearchTask? other)
    {
        return researchTask =>
            other != null &&
            other.Type == researchTask.Type &&
            other.Title == researchTask.Title &&
            other.Author == researchTask.Author &&
            other.Institution == researchTask.Institution &&
            other.Date == researchTask.Date &&
            other.StartDate == researchTask.StartDate &&
            other.EndDate == researchTask.EndDate &&
            other.FinancingAmount == researchTask.FinancingAmount &&
            other.Description == researchTask.Description &&
            other.FinancingApproved == researchTask.FinancingApproved;
    }
}