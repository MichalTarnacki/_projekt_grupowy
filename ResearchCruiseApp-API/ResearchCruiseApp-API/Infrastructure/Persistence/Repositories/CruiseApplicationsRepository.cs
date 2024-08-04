using ResearchCruiseApp_API.Application.ServicesInterfaces.Persistence.Repositories;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Infrastructure.Persistence.Repositories;


internal class CruiseApplicationsRepository : Repository<CruiseApplication>, ICruiseApplicationsRepository
{
    public CruiseApplicationsRepository(ApplicationDbContext dbContext) : base(dbContext)
    { }
    
    
    public async Task AddCruiseApplication(CruiseApplication cruiseApplication, CancellationToken cancellationToken)
    {
        await DbContext.CruiseApplications.AddAsync(cruiseApplication, cancellationToken);
    }
}