﻿using System.ComponentModel.DataAnnotations;

namespace ResearchCruiseApp_API.Domain.Entities;


public class FormBResearchEquipment : Entity
{
    public FormB FormB { get; init; } = null!;

    public ResearchEquipment ResearchEquipment { get; init; } = null!;

    [StringLength(1024)]
    public string? InsuranceStartDate { get; init; }
    
    [StringLength(1024)]
    public string? InsuranceEndDate { get; init; }

    [StringLength(1024)]
    public string Permission { get; init; } = null!;
}