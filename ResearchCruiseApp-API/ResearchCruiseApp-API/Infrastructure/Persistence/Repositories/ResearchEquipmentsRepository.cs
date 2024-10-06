using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Infrastructure.Persistence.Repositories;


internal class ResearchEquipmentsRepository : Repository<ResearchEquipment>, IResearchEquipmentsRepository
{
    protected ResearchEquipmentsRepository(ApplicationDbContext dbContext) : base(dbContext)
    { }
}