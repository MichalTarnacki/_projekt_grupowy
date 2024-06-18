using System.ComponentModel.DataAnnotations.Schema;
using ResearchCruiseApp_API.Data.Interfaces;

namespace ResearchCruiseApp_API.Data;

public class Cruise : IYearBasedNumberedEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Number { get; set; } = null!;
    
    public Guid MainCruiseManagerId { get; set; }

    public Guid MainDeputyManagerId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public List<Application> Applications { get; set; } = null!;
}