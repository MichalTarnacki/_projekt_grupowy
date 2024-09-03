using AutoMapper;
using Microsoft.CodeAnalysis;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;


public class CruiseApplicationEvaluationDetailsDto
{
    public List<FormAResearchTaskDto> FormAResearchTasks { get; init; } = [];
    
    public List<FormAContractDto> FormAContracts { get; init; }  = [];
    
    public List<UgUnitDto> UgUnits { get; init; } = [];
    
    public int UgUnitsPoints { get; init; }
    
    public List<FormAPublicationDto> FormAPublications { get; init; } = [];
    
    public List<FormASpubTaskDto> FormASpubTasks { get; init; } = [];


    // private class MapProfile : Profile
    // {
    //     public MapProfile()
    //     {
    //         CreateMap<CruiseApplication, CruiseApplicationEvaluationDetailsDto>()
    //             .ForMember(
    //                 dest => dest.FormAResearchTasks,
    //                 options =>
    //                     options.MapFrom(src => src.FormA))
    //     }
    // }
}