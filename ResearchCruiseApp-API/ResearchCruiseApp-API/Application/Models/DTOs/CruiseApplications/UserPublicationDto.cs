using AutoMapper;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;

public class UserPublicationDto
{
    public Guid Id { get; init; }

    public Guid UserId { get; init; }
    
    public Publication Publication { get; init; } = null!;
    
    private class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserPublication, UserPublicationDto>()
                .ForPath(
                    dest => dest.Publication.Doi,
                    options =>
                        options.MapFrom(src => src.Publication.Doi))
                .ForPath(
                    dest => dest.Publication.Title,
                    options =>
                        options.MapFrom(src => src.Publication.Title))
                .ForPath(
                    dest => dest.Publication.Authors,
                    options =>
                        options.MapFrom(src => src.Publication.Authors))
                .ForPath(
                    dest => dest.Publication.Category,
                    options =>
                        options.MapFrom(src => src.Publication.Category))
                .ForPath(
                    dest => dest.Publication.MinisterialPoints,
                    options =>
                        options.MapFrom(src => src.Publication.MinisterialPoints))
                .ForPath(
                    dest => dest.Publication.Magazine,
                    options =>
                        options.MapFrom(src => src.Publication.Magazine))
                .ForPath(
                    dest => dest.Publication.Year,
                    options =>
                        options.MapFrom(src => src.Publication.Year))
                .ForPath(
                    dest => dest.Publication.Id,
                    options =>
                        options.MapFrom(src => src.Publication.Id))
                .ForPath(
                    dest => dest.Publication.UserPublications,
                    options =>
                        options.Ignore())
                .ForPath(
                    dest => dest.Publication.FormAPublications,
                    options =>
                        options.Ignore());
        }
    }
}