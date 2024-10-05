using AutoMapper;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Models.DTOs.Cruises;


public class CruiseApplicationShortInfoDto
{
    public Guid Id { get; set; }

    public string Number { get; set; } = null!;
    
    public string Points { get; set; } = null!;


    private class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CruiseApplication, CruiseApplicationShortInfoDto>()
                .ForMember(
                dest => dest.Points,
                options=>
                    options.Ignore());
        }
    }
}   