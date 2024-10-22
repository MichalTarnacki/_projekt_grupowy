using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;


public interface IResearchEquipmentsRepository : IRepository<ResearchEquipment>
{
    Task<int> CountFormCAssociations(ResearchEquipment researchEquipment, CancellationToken cancellationToken);
    
    Task<int> CountUniqueFormsB(ResearchEquipment researchEquipment, CancellationToken cancellationToken);
}