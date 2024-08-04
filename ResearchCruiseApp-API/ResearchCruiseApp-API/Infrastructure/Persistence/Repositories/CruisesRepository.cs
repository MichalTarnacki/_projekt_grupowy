using ResearchCruiseApp_API.Application.ServicesInterfaces.Persistence.Repositories;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Infrastructure.Persistence.Repositories;


internal class CruisesRepository : Repository<Cruise>, ICruisesRepository
{
    public CruisesRepository(ApplicationDbContext dbContext) : base(dbContext)
    { }

    
    public async Task AddCruise(Cruise cruise, CancellationToken cancellationToken)
    {
        await DbContext.Cruises.AddAsync(cruise, cancellationToken);
    }
}