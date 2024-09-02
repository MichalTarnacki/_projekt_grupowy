using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchCruiseApp_API.Domain.Entities;


public class FormAGuestUnit : Entity
{
    public FormA FormA { get; set; } = null!;

    public GuestUnit GuestUnit { get; set; } = null!;
    
    public int NoOfPersons { get; set; }
}