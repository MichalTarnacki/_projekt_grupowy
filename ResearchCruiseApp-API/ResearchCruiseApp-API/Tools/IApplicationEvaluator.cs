using ResearchCruiseApp_API.Models;

namespace ResearchCruiseApp_API.Tools;

public interface IApplicationEvaluator
{
    public EvaluatedApplicationModel EvaluateApplication(FormsModel formA, List<ResearchTask> cruiseEffects);
}