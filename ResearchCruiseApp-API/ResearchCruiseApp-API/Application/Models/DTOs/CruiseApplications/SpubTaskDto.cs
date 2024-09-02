using AutoMapper;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;


public class SpubTaskDto
{
    public int YearFrom { get; set; }
    public int YearTo { get; set; }
    public string Name { get; set; } = null!;
    
    
    private class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<SpubTaskDto, SpubTask>()
                .ForMember(
                    dest => dest.Id,
                    options => options.Ignore())
                .ForMember(dest => dest.FormASpubTasks,
                    options => options.Ignore());

            CreateMap<SpubTask, SpubTaskDto>();
        }
    }
}