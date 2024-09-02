using AutoMapper;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;


public class PublicationDto
{
    public string Category { get; init; } = null!;

    public string Doi { get; init; } = null!;

    public string Authors { get; init; } = null!;

    public string Title { get; init; } = null!;

    public string Magazine { get; init; } = null!;
    
    public int Year { get; init; }
    
    public int MinisterialPoints { get; init; }


    private class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<PublicationDto, Publication>()
                .ForMember(
                    dest => dest.Id,
                    options =>
                        options.Ignore())
                .ForMember(
                    dest => dest.FormAPublications,
                    options =>
                        options.Ignore());
            
            CreateMap<Publication, PublicationDto>();
        }
    }
}