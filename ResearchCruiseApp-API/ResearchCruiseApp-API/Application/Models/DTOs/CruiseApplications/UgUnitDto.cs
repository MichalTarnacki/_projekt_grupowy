using AutoMapper;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;


public class UgUnitDto
{
    public Guid UgUnitId { get; set; }
    
    public int NoOfEmployees { get; set; }
    
    public int NoOfStudents { get; set; }
}