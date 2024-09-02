using AutoMapper;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Domain.Common.Interfaces;
using ResearchCruiseApp_API.Temp.Entities;

namespace ResearchCruiseApp_API.Temp.DTOs;


public class EvaluatedResearchTaskDto : ResearchTaskDto , IEvaluated
{
    public Guid Id;
    public ResearchTaskDto ResearchTask { get; set; }
    public int Points { get; set; }

    public EvaluatedResearchTaskDto(ResearchTaskDto taskDto, int calculatedPoints)
    {
        ResearchTask = taskDto;
        Points = calculatedPoints;
    }


    private class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<EvaluatedResearchTaskDto, EvaluatedResearchTask>()
                .ForPath(dest => dest.ResearchTask.Title, act => act.MapFrom(src => src.Values.Title))
                .ForPath(dest => dest.ResearchTask.Author, act => act.MapFrom(src => src.Values.Author))
                .ForPath(dest => dest.ResearchTask.Institution, act => act.MapFrom(src => src.Values.Institution))
                .ForPath(dest => dest.ResearchTask.Date, act => act.MapFrom(src => src.Values.Date))
                .ForPath(dest => dest.ResearchTask.StartDate, act => act.MapFrom(src => src.Values.Time.HasValue ? src.Values.Time.Value.Start : null))
                .ForPath(dest => dest.ResearchTask.EndDate, act => act.MapFrom(src => src.Values.Time.HasValue ? src.Values.Time.Value.End : null))
                .ForPath(dest => dest.ResearchTask.FinancingAmount, act => act.MapFrom(src => src.Values.FinancingAmount))
                .ForPath(dest => dest.ResearchTask.Description, act => act.MapFrom(src => src.Values.Description))
                .ReverseMap();
        }
    }
}

public class EvaluatedContractDto : ContractDto, IEvaluated
{
    public Guid Id;
    public int Points { get; set; }
    public ContractDto ContractDto { get; set; }

    public EvaluatedContractDto(ContractDto contractDto, int calculatedPoints)
    {
        this.ContractDto = contractDto;
        this.Points = calculatedPoints;
    }


    private class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<EvaluatedContractDto, EvaluatedContract>()
                .ReverseMap();
        }
    }
}

public class EvaluatedPublicationDto : PublicationDto, IEvaluated
{
    public Guid Id;
    public PublicationDto Publication { get; set; }
    public int Points { get; set; }

    public EvaluatedPublicationDto(PublicationDto publicationDto, int calculatedPoints)
    {
        this.Publication = publicationDto;
        this.Points = calculatedPoints;
    }


    private class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<EvaluatedPublicationDto, EvaluatedPublication>()
                .ReverseMap();
        }
    }
}

public class EvaluatedSpubTaskDto : SpubTaskDto, IEvaluated
{
    public Guid Id;
    public SpubTaskDto SpubTask { get; set; }
    public int Points { get; set; }

    public EvaluatedSpubTaskDto(SpubTaskDto spubTaskDto, int calculatedPoints)
    {
        this.SpubTask = spubTaskDto;
        this.Points = calculatedPoints;
    }


    private class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<EvaluatedSpubTaskDto, EvaluatedSpubTask>()
                .ReverseMap();
        }
    }
}