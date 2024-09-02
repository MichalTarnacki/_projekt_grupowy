using ResearchCruiseApp_API.Domain.Entities;
using ResearchCruiseApp_API.Temp.Entities;
using Contract = ResearchCruiseApp_API.Domain.Entities.Contract;
using EvaluatedContract = ResearchCruiseApp_API.Temp.Entities.EvaluatedContract;
using EvaluatedPublication = ResearchCruiseApp_API.Temp.Entities.EvaluatedPublication;
using EvaluatedResearchTask = ResearchCruiseApp_API.Temp.Entities.EvaluatedResearchTask;
using Publication = ResearchCruiseApp_API.Domain.Entities.Publication;
using ResearchTask = ResearchCruiseApp_API.Domain.Entities.ResearchTask;

namespace ResearchCruiseApp_API.Temp.Tools;


public class CruiseApplicationEvaluator : ICruiseApplicationEvaluator
{
    private const int DefaultPoints = 0;

    private const int BaThesis = 0;
    private const int BaThesisPoints = 20;

    private const int MScThesis = 1;
    private const int MScThesisPoints = 50;

    private const int PhDThesis = 2;
    private const int PhDThesisPoints = 100;

    private const int ScOrRdProject = 3;
    private const int ScOrRdProjectFinancingApprovedPoints = 100;
    private const int ScOrRdProjectFinancingNotApprovedPoints = 150;

    private const int DomesticProject = 4;
    private const int DomesticProjectPoints = 50;
    private const float DomesticProjectPointsRatio = 1 / 100_000f;

    private const int ForeignProject = 5;
    private const int ForeignProjectPoints = 80;
    private const float ForeignProjectPointsRatio = 1 / 100_000f;

    private const int InternalProject = 6;
    private const int InternalProjectPoints = 30;

    private const int CommercialProject = 7;

    private const int DidacticsProject = 8;

    private const int OwnProjectRealizationProject = 9;
    private const int OwnProjectRealizationPoints = 100;

    private const int OtherProject = 10;

    private const string DomesticContract = "domestic";
    private const int DomesticContractPoints = 150;

    private const string InternationalContract = "international";
    private const int ForeignContractPoints = 300;

    private const int UgTeamPointsFromAtLeast3Units = 100;
    private const int UgTeamPointsFromAtLeast2Units = 50;

    private const string DefaultPublication = "subject";
    private const float DefaultPublicationPointRatio = 0.5f;

    private const string PublicationFromRV = "postscript";
    private const float PublicationFromRVPointRatio = 1;

    private const int SpubTaskPoints = 100;


    public EvaluatedCruiseApplication EvaluateCruiseApplication(FormA formA, List<ResearchTask> cruiseEffects)
    {
        var evaluatedApplication = new EvaluatedCruiseApplication();

        if (formA.FormAResearchTasks.Count != 0)
        {
            foreach (var researchTask in formA.FormAResearchTasks)
            {
                //evaluatedApplication.ResearchTasks.Add(EvaluateResearchTask(researchTask));
            }
        }

        if (formA.Contracts.Count != 0)
        {
            foreach (var contract in formA.Contracts)
            {
                evaluatedApplication.Contracts.Add(EvaluateContract(contract));
            }
        }

        var emptyTeams = 0;
        foreach (var ugTeam in formA.FormAUgUnits)
        {
            if (ugTeam.NoOfEmployees <= 0 && ugTeam.NoOfStudents <= 0)
                emptyTeams++;
        }

        if (formA.FormAUgUnits.Count - emptyTeams >= 3)
            evaluatedApplication.UgTeamsPoints = UgTeamPointsFromAtLeast3Units;
        else if (formA.FormAUgUnits.Count - emptyTeams >= 2)
            evaluatedApplication.UgTeamsPoints = UgTeamPointsFromAtLeast2Units;
        else
            evaluatedApplication.UgTeamsPoints = DefaultPoints;

        foreach (var publication in formA.FormAPublications)
        {
            //evaluatedApplication.Publications.Add(EvaluatePublication(publication));
        }

        foreach (var cruiseEffect in cruiseEffects)
        {
             evaluatedApplication.CruiseEffects.Add(EvaluateResearchTask(cruiseEffect));   
        }

        foreach (var spubTask in formA.FormASpubTasks)
        {
            //evaluatedApplication.SpubTasks.Add(EvaluateSpubTask(spubTask));
        }

        return evaluatedApplication;
    }

    
    public EvaluatedResearchTask EvaluateResearchTask(ResearchTask researchTask)
    {
        if (researchTask.Type == BaThesis)
            return new EvaluatedResearchTask{ResearchTask = researchTask, CalculatedPoints = BaThesisPoints};
        if (researchTask.Type == MScThesis)
            return new EvaluatedResearchTask{ResearchTask = researchTask, CalculatedPoints = MScThesisPoints};
        if (researchTask.Type == PhDThesis)
            return new EvaluatedResearchTask{ResearchTask = researchTask, CalculatedPoints = PhDThesisPoints};
        if (researchTask.Type == ScOrRdProject)
        {
            //  if(researchTask.isFinancingApproved)
            //     return new EvaluatedResearchTask{ResearchTask = researchTask, CalculatedPoints = 
            //          C.ScOrRdProjectFinancingApprovedPoints};

            return new EvaluatedResearchTask{ResearchTask = researchTask, 
                CalculatedPoints = ScOrRdProjectFinancingNotApprovedPoints};

        }

        // if (researchTask.Type == DomesticProject)
        //     return new EvaluatedResearchTask{ResearchTask = researchTask, CalculatedPoints = (int)(DomesticProjectPoints
        //                                                          * Math.Floor(
        //                                                              float.Parse(researchTask.FinancingAmount, CultureInfo.InvariantCulture)
        //                                                              * DomesticProjectPointsRatio))};
        // if (researchTask.Type == ForeignProject)
        //     return new EvaluatedResearchTask{ResearchTask = researchTask, CalculatedPoints = (int)(ForeignProjectPoints
        //                                                          * Math.Floor(
        //                                                              float.Parse(researchTask.FinancingAmount, CultureInfo.InvariantCulture)
        //                                                              * ForeignProjectPointsRatio))};
        if (researchTask.Type == InternalProject)
            return new EvaluatedResearchTask{ResearchTask = researchTask, CalculatedPoints = InternalProjectPoints};
        if (researchTask.Type == CommercialProject)
            return new EvaluatedResearchTask{ResearchTask = researchTask, CalculatedPoints = DefaultPoints};
        if (researchTask.Type == DidacticsProject)
            return new EvaluatedResearchTask{ResearchTask = researchTask, CalculatedPoints = DefaultPoints};
        if (researchTask.Type == OwnProjectRealizationProject)
            return new EvaluatedResearchTask{ResearchTask = researchTask, CalculatedPoints = OwnProjectRealizationPoints};
        if (researchTask.Type == OtherProject)
            return new EvaluatedResearchTask{ResearchTask = researchTask, CalculatedPoints = DefaultPoints};

        return new EvaluatedResearchTask{ResearchTask = researchTask, CalculatedPoints = DefaultPoints};
    }

    private EvaluatedContract EvaluateContract(Contract contract)
    {
        if (contract.Category == DomesticContract)
            return new EvaluatedContract{Contract = contract, CalculatedPoints = DomesticContractPoints};
        if (contract.Category == InternationalContract)
            return new EvaluatedContract { Contract = contract, CalculatedPoints = ForeignContractPoints };

        return new EvaluatedContract{Contract = contract, CalculatedPoints = DefaultPoints};
    }

    private EvaluatedPublication EvaluatePublication(Publication publication)
    {
        if (publication.Category == DefaultPublication)
            return new EvaluatedPublication{Publication = publication,
                CalculatedPoints = (int)(DefaultPublicationPointRatio * publication.MinisterialPoints)};
        if (publication.Category == PublicationFromRV)
            return new EvaluatedPublication
            {
                Publication = publication,
                CalculatedPoints = (int)(PublicationFromRVPointRatio * publication.MinisterialPoints)
            };

        return new EvaluatedPublication{Publication = publication,
            CalculatedPoints = DefaultPoints};
    }

    private EvaluatedSpubTask EvaluateSpubTask(SpubTask spubTask)
    {
        return new EvaluatedSpubTask{SpubTask = spubTask, CalculatedPoints = SpubTaskPoints};
    }
    
    public int CalculateSumOfPoints(EvaluatedCruiseApplication evaluatedCruiseApplication)
    {
        var sum = 0;

        foreach (var researchTask in evaluatedCruiseApplication.ResearchTasks)
        {
            sum += researchTask.CalculatedPoints;
        }
            
        foreach (var contract in evaluatedCruiseApplication.Contracts)
        {
            sum += contract.CalculatedPoints;
        }

        sum += evaluatedCruiseApplication.UgTeamsPoints;
            
        foreach (var publication in evaluatedCruiseApplication.Publications)
        {
            sum += publication.CalculatedPoints;
        }
            
        foreach (var cruiseEffect in evaluatedCruiseApplication.CruiseEffects)
        {
            sum += cruiseEffect.CalculatedPoints;
        }
            
        foreach (var spubTask in evaluatedCruiseApplication.SpubTasks)
        {
            sum += spubTask.CalculatedPoints;
        }

        return sum;
    }
}