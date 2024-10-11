﻿using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;


public class CollectedSampleDto
{
    [StringLength(1024)]
    public string Type { get; init; } = null!;
    
    [StringLength(1024)]
    public string Amount { get; init; } = null!;
    
    [StringLength(1024)]
    public string Analysis { get; init; } = null!;

    [StringLength(1024)]
    public string Publishing { get; init; } = null!;


    private class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CollectedSampleDto, CollectedSample>();
            
            CreateMap<CollectedSample, CollectedSampleDto>();
        }
    }
}