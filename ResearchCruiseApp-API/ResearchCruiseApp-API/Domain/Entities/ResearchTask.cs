using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ResearchCruiseApp_API.Domain.Common.Enums;

namespace  ResearchCruiseApp_API.Domain.Entities;


public class ResearchTask : Entity
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
    
    public double? FinancingAmount { get; init; }
    
    [StringLength(1024)]
    public string? Description { get; init; }

    public bool? FinancingApproved { get; init; }
    
    public List<FormAResearchTask> FormAResearchTasks { get; set; } = [];


    public override bool Equals(object? other)
    {
        if (other is null)
            return false;

        var otherResearchTask = (ResearchTask)other;

        return otherResearchTask.Type == Type &&
               otherResearchTask.Title == Title &&
               otherResearchTask.Author == Author &&
               otherResearchTask.Institution == Institution &&
               otherResearchTask.Date == Date &&
               otherResearchTask.StartDate == StartDate &&
               otherResearchTask.EndDate == EndDate &&
               Equals(otherResearchTask.FinancingAmount, FinancingAmount) &&
               otherResearchTask.Description == Description &&
               otherResearchTask.FinancingApproved == FinancingApproved;
    }

    public override int GetHashCode()
    {
        return Type.GetHashCode() +
            Title?.GetHashCode() ?? 0 +
            Author?.GetHashCode() ?? 0 +
            Institution?.GetHashCode() ?? 0 +
            Date?.GetHashCode() ?? 0 +
            StartDate?.GetHashCode() ?? 0 +
            EndDate?.GetHashCode() ?? 0 +
            FinancingAmount?.GetHashCode() ?? 0 +
            Description?.GetHashCode() ?? 0 +
            FinancingApproved.GetHashCode();
    }
}