using ResearchCruiseApp_API.Domain.Common.Attributes;

namespace ResearchCruiseApp_API.Domain.Common.Enums;


public enum CruiseApplicationStatus
{
    [StringValue("Oczekujące na akceptację przez przełożonego")]
    WaitingForSupervisorAcceptance,
    
    [StringValue("Odrzucone przez przełożonego")]
    DeniedBySupervisor,
    
    [StringValue("Nowe")]
    New,
        
    [StringValue("Zaakceptowane")]
    Accepted,
        
    [StringValue("Zrealizowane")]
    Undertaken,
        
    [StringValue("Rozliczone")]
    Reported
}