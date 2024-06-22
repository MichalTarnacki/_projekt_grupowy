namespace ResearchCruiseApp_API.Models;

public class EvaluatedApplicationModel
{
    public List<EvaluatedResearchTask> ResearchTasks { get; set; } 
    
    public List<EvaluatedContract> Contracts { get; set; } 
    
    public List<UGTeam> UgTeams { get; set; }
    public int UgTeamsPoints { get; set; }
    
    public List<GuestTeam> GuestTeams { get; set; }
    
    public List<EvaluatedPublication> Publications { get; set; }
    
    public List<EvaluatedCruiseEffects> CruiseEffects{ get; set; }

    public List<EvaluatedSPUBTask> SpubTasks { get; set; } 
    
  
    
    public EvaluatedApplicationModel(FormAModel formA, List<ResearchTask> cruiseEffects)
    {
        foreach (var researchTask in formA.ResearchTasks)
        {
         ResearchTasks.Add(EvaluateResearchTask(researchTask));   
        }
        foreach (var contract in formA.Contracts)
        {
            Contracts.Add(EvaluateContract(contract));   
        }

        UgTeams = formA.UgTeams;
        var UgTeamsFromWOiG = 0;
        foreach (var team in UgTeams)
        {
            if (isInWOiG(team.UnitId))
                UgTeamsFromWOiG++;
        }

        if (UgTeamsFromWOiG >= 3)
            UgTeamsPoints = C.UgTeamPointsFromAtLeast3WOiGUnits;
        else if(UgTeamsFromWOiG >= 2)
            UgTeamsPoints = C.UgTeamPointsFromAtLeast2WOiGUnits;
        else
            UgTeamsPoints = C.DefaultPoints;
        
        foreach (var publication in formA.Publications)
        {
            Publications.Add(EvaluatePublication(publication));   
        }
        
        foreach (var cruiseEffect in CruiseEffects)
        {
            CruiseEffects.Add(EvaluateResearchTask(cruiseEffect));   
        }
        
        foreach (var spubTask in formA.SpubTasks)
        {
            SpubTasks.Add(EvaluateSpubTask(spubTask));   
        }
        
    }
    
    public EvaluatedResearchTask EvaluateResearchTask(ResearchTask task)
    {
            if (researchTask.Type = C.BaThesis)
                return new EvaluatedResearchTask(researchTask, C.BaThesisPoints);
            if (researchTask.Type = C.MScThesis)
                return new EvaluatedResearchTask(researchTask, C.MScThesisPoints);
            if (researchTask.Type = C.PhDThesis)
                return new EvaluatedResearchTask(researchTask, C.PhDThesisPoints);
            if (researchTask.Type = C.ScOrRdProject)
            {
                if(researchTask.isFinancingApproved)
                    return new EvaluatedResearchTask(researchTask,
                        C.ScOrRdProjectFinancingApprovedPoints);
                
                {
                    return new EvaluatedResearchTask(researchTask,
                        C.ScOrRdProjectFinancingNotApprovedPoints);
                }
            }
            if (researchTask.Type = C.DomesticProject)
                return new EvaluatedResearchTask(researchTask, C.DomesticProjectPoints 
                                                                          * Math.Floor(researchTask.FinancingAmount 
                                                                              * C.DomesticProjectPointsRatio));
            if (researchTask.Type = C.ForeignProject)
                return new EvaluatedResearchTask(researchTask, C.ForeignProjectPoints 
                                                                          * Math.Floor(researchTask.FinancingAmount 
                                                                              * C.ForeignProjectPointsRatio));
            if (researchTask.Type = C.InternalProject)
                return new EvaluatedResearchTask(researchTask, C.InternalProjectPoints);
            if (researchTask.Type = C.CommercialProject)
                return new EvaluatedResearchTask(researchTask, C.CommercialProjectPoints);
            if (researchTask.Type = C.DidacticsProject)
                return new EvaluatedResearchTask(researchTask, C.DidacticsProjectPoints);
            if (researchTask.Type = C.OwnProjectRealizationProject)
                return new EvaluatedResearchTask(researchTask, C.OwnProjectRealizationPoints);
            if (researchTask.Type = C.OtherProject)
                return new EvaluatedResearchTask(researchTask, C.OtherProjectPoints);
            
            return new  EvaluatedResearchTask(researchTask, C.DefaultPoints);
    }
    
      public EvaluatedContract EvaluateContract(Contract contract)
      {
            if(contract.Category == C.DomesticContract)
                return new EvaluatedContract(contract, C.DomesticContractPoints);
            if(contract.Category == C.ForeignContract)
                return new  EvaluatedContract(contract, C.ForeignContractPoints);
            
            return new  EvaluatedContract(contract, C.DefaultPoints);
      }
      
      public EvaluatedPublication EvaluatePublication(Publication publication)
      {
          if(publication.Category == C.DefaultPublication)
              return new EvaluatedPublication(publication, C.DefaultPublicatioPoints);
          if(publication.Category == C.PublicationFromRV)
              return new  EvaluatedPublication(publication, C.PublicationFromRVPoints);
            
          return new  EvaluatedPublication(publication, C.DefaultPoints);
      }
      public EvaluatedSpubTask EvaluateSpubTask(SPUBTask spubTask)
      {
          return new  EvaluatedSpubTask(spubTask, C.SpubTaskPoints);
      }
}