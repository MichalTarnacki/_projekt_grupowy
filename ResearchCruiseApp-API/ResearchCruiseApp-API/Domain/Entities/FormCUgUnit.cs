﻿using System.ComponentModel.DataAnnotations;

namespace ResearchCruiseApp_API.Domain.Entities;


public class FormCUgUnit : Entity
{
    public FormC FormC { get; init; } = null!;

    public UgUnit UgUnit { get; init; } = null!;

    [StringLength(1024)]
    public string NoOfEmployees { get; init; } = null!;
    
    [StringLength(1024)]
    public string NoOfStudents { get; init; } = null!;
}