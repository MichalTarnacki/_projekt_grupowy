using AutoMapper;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;


public class ResearchTaskDto
{
    public int Type { get; set; }

    public ResearchTaskValuesDto Values { get; set; } = null!;
    
    
    private class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<FormAResearchTask, ResearchTaskDto>()
                .ForMember(
                    dest => dest.Type,
                    options =>
                        options.MapFrom(src => src.ResearchTask.Type))
                .ForMember(
                    dest => dest.Values,
                    options =>
                        options.MapFrom(src => src.ResearchTask));
            
            CreateMap<ResearchTaskDto, ResearchTask>()
                .ForMember(
                    dest => dest.Title,
                    options =>
                        options.MapFrom(src => src.Values.Title))
                .ForMember(
                    dest => dest.Author,
                    options =>
                        options.MapFrom(src => src.Values.Author))
                .ForMember(
                    dest => dest.Institution,
                    options =>
                        options.MapFrom(src => src.Values.Institution))
                .ForMember(
                    dest => dest.Date,
                    options =>
                        options.MapFrom(src => src.Values.Date))
                .ForMember(
                    dest => dest.StartDate,
                    options =>
                        options.MapFrom(src => src.Values.Time.HasValue
                            ? src.Values.Time.Value.Start
                            : null))
                .ForMember(
                    dest => dest.EndDate,
                    options =>
                        options.MapFrom(src => src.Values.Time.HasValue
                            ? src.Values.Time.Value.End
                            : null))
                .ForMember(
                    dest => dest.EndDate,
                    options =>
                        options.MapFrom(src => src.Values.Time.HasValue
                            ? src.Values.Time.Value.End
                            : null))
                .ForMember(
                    dest => dest.FinancingAmount,
                    options =>
                        options.MapFrom(src => src.Values.FinancingAmount))
                .ForMember(
                    dest => dest.Description,
                    options =>
                        options.MapFrom(src => src.Values.Description))
                .ForMember(
                    dest => dest.FinancingApproved,
                    options =>
                        options.MapFrom(src => src.Values.FinancingApproved));
        }
    }
}