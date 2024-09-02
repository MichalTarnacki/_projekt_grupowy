using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Domain.Common.Interfaces;

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
}