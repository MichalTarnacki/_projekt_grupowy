namespace ResearchCruiseApp_API.Models;
using C = ResearchCruiseApp_API.Data.Classes.Constants;
public class EvaluatedApplicationModel
{
    public List<EvaluatedResearchTask> ResearchTasks { get; set; } 
    
    public List<EvaluatedContract> Contracts { get; set; } 
    
    public List<UGTeam> UgTeams { get; set; }
    public int UgTeamsPoints { get; set; }
    
    public List<GuestTeam> GuestTeams { get; set; }
    
    public List<EvaluatedPublication> Publications { get; set; }
    
    public List<ResearchTask> CruiseEffects{ get; set; }

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

        GuestTeams = formA.GuestTeams;
        
        UgTeams = formA.UgTeams;

        if (UgTeams.Count >= 3)
            UgTeamsPoints = C.UgTeamPointsFromAtLeast3Units;
        else if(UgTeams.Count >= 2)
            UgTeamsPoints = C.UgTeamPointsFromAtLeast2Units;
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
    
    public EvaluatedResearchTask EvaluateResearchTask(ResearchTask researchTask)
    {
            if (researchTask.Type == C.BaThesis)
                return new EvaluatedResearchTask(researchTask, C.BaThesisPoints);
            if (researchTask.Type == C.MScThesis)
                return new EvaluatedResearchTask(researchTask, C.MScThesisPoints);
            if (researchTask.Type == C.PhDThesis)
                return new EvaluatedResearchTask(researchTask, C.PhDThesisPoints);
            if (researchTask.Type == C.ScOrRdProject)
            {
              //  if(researchTask.isFinancingApproved)
              //     return new EvaluatedResearchTask(researchTask,
              //          C.ScOrRdProjectFinancingApprovedPoints);

                return new EvaluatedResearchTask(researchTask,
                        C.ScOrRdProjectFinancingNotApprovedPoints);
                
            }
            if (researchTask.Type == C.DomesticProject)
                return new EvaluatedResearchTask(researchTask, (int)(C.DomesticProjectPoints 
                                                                          * Math.Floor(Int32.Parse(researchTask.Values.FinancingAmount)
                                                                              * C.DomesticProjectPointsRatio)));
            if (researchTask.Type == C.ForeignProject)
                return new EvaluatedResearchTask(researchTask, (int)(C.ForeignProjectPoints 
                                                                     * Math.Floor(Int32.Parse(researchTask.Values.FinancingAmount)
                                                                         * C.ForeignProjectPointsRatio)));
            if (researchTask.Type == C.InternalProject)
                return new EvaluatedResearchTask(researchTask, C.InternalProjectPoints);
            if (researchTask.Type == C.CommercialProject)
                return new EvaluatedResearchTask(researchTask, C.DefaultPoints);
            if (researchTask.Type == C.DidacticsProject)
                return new EvaluatedResearchTask(researchTask, C.DefaultPoints);
            if (researchTask.Type == C.OwnProjectRealizationProject)
                return new EvaluatedResearchTask(researchTask, C.OwnProjectRealizationPoints);
            if (researchTask.Type == C.OtherProject)
                return new EvaluatedResearchTask(researchTask, C.DefaultPoints);
            
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
              return new EvaluatedPublication(publication, (int)(C.DefaultPublicationPointRatio*publication.Points));
          if(publication.Category == C.PublicationFromRV)
              return new  EvaluatedPublication(publication, (int)(C.PublicationFromRVPointRatio*publication.Points));
            
          return new  EvaluatedPublication(publication, C.DefaultPoints);
      }
      public EvaluatedSPUBTask EvaluateSpubTask(SPUBTask spubTask)
      {
          return new  EvaluatedSPUBTask(spubTask, C.SpubTaskPoints);
      }
}