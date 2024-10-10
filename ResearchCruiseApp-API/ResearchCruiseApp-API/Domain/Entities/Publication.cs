using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using ResearchCruiseApp_API.Domain.Common.Interfaces;

namespace ResearchCruiseApp_API.Domain.Entities;


public class Publication: Entity, IEquatableByExpression<Publication>
{
    [StringLength(1024)]
    public string Category { get; init; } = null!;
    
    [StringLength(1024)]
    public string Doi { get; init; } = null!;
    
    [StringLength(1024)]
    public string Authors { get; init; } = null!;
    
    [StringLength(1024)]
    public string Title { get; init; } = null!;
    
    [StringLength(1024)]
    public string Magazine { get; init; } = null!;

    [StringLength(1024)]
    public string Year { get; init; } = null!;

    [StringLength(1024)]
    public string MinisterialPoints { get; init; } = null!;
    
    public List<FormAPublication> FormAPublications { get; init; } = [];

    
    public static Expression<Func<Publication, bool>> EqualsByExpression(Publication? other)
    {
        return publication =>
            other != null &&
            other.Category == publication.Category &&
            other.Doi == publication.Doi &&
            other.Authors == publication.Authors &&
            other.Title == publication.Title &&
            other.Magazine == publication.Magazine &&
            other.Year == publication.Year &&
            other.MinisterialPoints == publication.MinisterialPoints;
    }
}