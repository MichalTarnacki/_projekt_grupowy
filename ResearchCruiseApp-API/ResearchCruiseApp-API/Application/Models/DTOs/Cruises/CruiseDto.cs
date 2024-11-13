using AutoMapper;
using ResearchCruiseApp_API.Application.Common.Extensions;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Models.DTOs.Cruises;


public class CruiseDto
{
    public Guid Id { get; set; }
    
    public string Number { get; set; } = null!;

    public string StartDate { get; set; } = null!;

    public string EndDate { get; set; } = null!;
    
    public Guid MainCruiseManagerId { get; set; }
    
    public string MainCruiseManagerFirstName { get; set; } = null!;
    
    public string MainCruiseManagerLastName { get; set; } = null!;
    
    public Guid MainDeputyManagerId { get; set; }
    
    public List<CruiseApplicationShortInfoDto> CruiseApplicationsShortInfo { get; set; } = [];

    public string Status { get; init; } = null!;

    
    private class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Cruise, CruiseDto>()
                .ForMember(
                    dest => dest.Status,
                    options =>
                        options.MapFrom(src => 
                            src.Status.GetStringValue()
                        ))
                .ForMember(
                    dest => dest.CruiseApplicationsShortInfo,
                    options=>
                        options.Ignore());
        }
    }
}   