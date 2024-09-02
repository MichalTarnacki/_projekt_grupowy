using System.Diagnostics;
using System.Globalization;
using ResearchCruiseApp_API.Application.Common.Constants;
using ResearchCruiseApp_API.Domain.Common.Enums;
using ResearchCruiseApp_API.Domain.Common.Extensions;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Services.CruiseApplicationEvaluator;


public class CruiseApplicationEvaluator : ICruiseApplicationEvaluator
{
    public void Evaluate(CruiseApplication cruiseApplication)
    {
        if (cruiseApplication.FormA is null)
            return;
        
        EvaluateResearchTasks(cruiseApplication);
        EvaluateContracts(cruiseApplication);
        EvaluateUgUnits(cruiseApplication);
        EvaluatePublications(cruiseApplication);
        EvaluateSpubTasks(cruiseApplication);
    }


    private static void EvaluateResearchTasks(CruiseApplication cruiseApplication)
    {
        Debug.Assert(cruiseApplication.FormA is not null);
        
        foreach (var formAResearchTask in cruiseApplication.FormA.FormAResearchTasks)
        {
            var researchTask = formAResearchTask.ResearchTask;
            
            formAResearchTask.Points = researchTask.Type switch
            {
                ResearchTaskType.BachelorThesis =>
                    EvaluationConstants.PointsForBachelorThesisResearchTask,

                ResearchTaskType.MasterThesis =>
                    EvaluationConstants.PointsForMasterThesisResearchTask,

                ResearchTaskType.DoctoralThesis =>
                    EvaluationConstants.PointsForDoctoralThesisResearchTask,

                ResearchTaskType.ProjectPreparation =>
                    researchTask.FinancingApproved
                        ? EvaluationConstants.PointsForProjectPreparationWithFinancing
                        : EvaluationConstants.PointsForProjectPreparationWithoutFinancing,

                ResearchTaskType.DomesticProject when researchTask.FinancingAmount is not null =>
                    EvaluationConstants.PointsPerDivisionForDomesticProject *
                    (int)(researchTask.FinancingAmount / EvaluationConstants.DomesticProjectDivision),

                ResearchTaskType.ForeignProject when researchTask.FinancingAmount is not null =>
                    EvaluationConstants.PointsPerDivisionForForeignProject *
                    (int)(researchTask.FinancingAmount / EvaluationConstants.ForeignProjectDivision),

                ResearchTaskType.InternalUgProject =>
                    EvaluationConstants.PointsForInternalUgProject,

                ResearchTaskType.OwnResearchTask =>
                    EvaluationConstants.PointsForOwnResearchTask,

                _ => 0
            };
        }
    }

    private static void EvaluateContracts(CruiseApplication cruiseApplication)
    {
        Debug.Assert(cruiseApplication.FormA is not null);

        foreach (var formAContract in cruiseApplication.FormA.FormAContracts)
        {
            var contract = formAContract.Contract;

            if (contract.Category == ContractCategory.Domestic.GetStringValue())
                formAContract.Points = EvaluationConstants.PointsForDomesticContract;
            if (contract.Category == ContractCategory.International.GetStringValue())
                formAContract.Points = EvaluationConstants.PointsForInternationalContract;
        }
    }

    private static void EvaluateUgUnits(CruiseApplication cruiseApplication)
    {
        Debug.Assert(cruiseApplication.FormA is not null);

        var notEmptyTeamsCount = cruiseApplication.FormA.FormAUgUnits
            .Count(formAUgUnit => formAUgUnit.NoOfEmployees > 0 || formAUgUnit.NoOfStudents > 0);

        cruiseApplication.FormA.UgUnitsPoints = notEmptyTeamsCount switch
        {
            >= 3 => EvaluationConstants.PointsFor3OrMoreUgUnits,
            2 => EvaluationConstants.PointsFor2UgUnits,
            _ => 0
        };
    }
    
    private static void EvaluatePublications(CruiseApplication cruiseApplication)
    {
        Debug.Assert(cruiseApplication.FormA is not null);
        
        foreach (var formAPublication in cruiseApplication.FormA.FormAPublications)
        {
            var publication = formAPublication.Publication;
            
            double ministerialPointsRatio = 0;
            if (publication.Category == PublicationCategory.Subject.GetStringValue())
                ministerialPointsRatio = EvaluationConstants.MinisterialPointsRatioForSubjectPublication;
            if (publication.Category == PublicationCategory.Postscript.GetStringValue())
                ministerialPointsRatio = EvaluationConstants.MinisterialPointsRatioForPostscriptPublication;
            
            formAPublication.Points = (int)(publication.MinisterialPoints * ministerialPointsRatio);
        }
    }

    private static void EvaluateSpubTasks(CruiseApplication cruiseApplication)
    {
        Debug.Assert(cruiseApplication.FormA is not null);

        foreach (var formASpubTask in cruiseApplication.FormA.FormASpubTasks)
        {
            formASpubTask.Points = EvaluationConstants.PointsForSpubTask;
        }
    }

    public int GetPointsSum(CruiseApplication cruiseApplication)
    {
        var formA = cruiseApplication.FormA;
        if (formA is null)
            return 0;

        var researchTaskPoints = formA.FormAResearchTasks
            .Sum(formAResearchTask => formAResearchTask.Points);
        var contractsPoints = formA.FormAContracts
            .Sum(formAContract => formAContract.Points);
        var publicationsPoints = formA.FormAPublications
            .Sum(formAPublication => formAPublication.Points);
        var spubTasksPoints = formA.FormASpubTasks
            .Sum(formASpubTask => formASpubTask.Points);

        return researchTaskPoints + contractsPoints + formA.UgUnitsPoints + publicationsPoints + spubTasksPoints;
    }
}