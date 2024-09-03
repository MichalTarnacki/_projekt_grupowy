using AutoMapper;
using ResearchCruiseApp_API.Application.Common.Models.DTOs;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;


public class ResearchTaskValuesDto
{
    public string? Title { get; init; }
        
    public string? Author { get; init; }
        
    public string? Institution { get; init; }
        
    public string? Date { get; init; }
        
    public StringRangeDto? Time { get; init; }
        
    public double? FinancingAmount { get; init; }
        
    public string? Description { get; init; }

    public bool? FinancingApproved { get; init; }
    
    
    private class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ResearchTask, ResearchTaskValuesDto>()
                .ForMember(
                    dest => dest.Time,
                    options =>
                        options.MapFrom(src => src.StartDate != null && src.EndDate != null
                            ? new StringRangeDto{ Start = src.StartDate, End = src.EndDate }
                            : (StringRangeDto?)null));
        }
    }
}