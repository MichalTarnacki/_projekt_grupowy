using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchCruiseApp_API.Domain.Entities;


public class FormAUgUnit : Entity
{
    public FormA FormA { get; set; } = null!;

    public UgUnit UgUnit { get; set; } = null!;
    
    public int NoOfEmployees { get; set; }
    
    public int NoOfStudents { get; set; }
}