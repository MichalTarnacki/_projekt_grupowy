using AutoMapper;
using ResearchCruiseApp_API.Application.Models.Interfaces;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;


public class ResearchTaskEffectDto : IResearchTaskDto
{
    public string Type { get; init; } = null!;

    public string? Title { get; init; }
        
    public string? Author { get; init; }
        
    public string? Institution { get; init; }
        
    public string? Date { get; init; }
        
    public string? StartDate { get; init; }
    
    public string? EndDate { get; init; }
        
    public string? FinancingAmount { get; init; }
    
    public string? FinancingApproved { get; init; }
        
    public string? Description { get; init; }

    public string? SecuredAmount { get; init; }

    public string? MinisterialPoints { get; init; }
    
    public string Done { get; init; } = null!;

    public string ManagerConditionMet { get; init; } = null!;
    
    public string DeputyConditionMet { get; init; } = null!;


    private class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ResearchTask, ResearchTaskEffectDto>()
                .ForMember(
                    dest => dest.Type,
                    options =>
                        options.MapFrom(src => ((int)src.Type).ToString()));
        }
    }
}