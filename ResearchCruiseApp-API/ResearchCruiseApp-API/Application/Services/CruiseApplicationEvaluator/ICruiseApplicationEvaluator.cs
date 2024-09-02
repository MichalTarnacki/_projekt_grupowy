using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Services.CruiseApplicationEvaluator;


public interface ICruiseApplicationEvaluator
{
    void Evaluate(CruiseApplication cruiseApplication);
    public int GetPointsSum(CruiseApplication cruiseApplication);
}