using Microsoft.EntityFrameworkCore;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Infrastructure.Persistence.Repositories;


internal class ResearchTasksEffectsRepository : Repository<ResearchTaskEffect>, IResearchTaskEffectsRepository
{
    public ResearchTasksEffectsRepository(ApplicationDbContext dbContext) : base(dbContext)
    { }

    public Task<int> GetEffectsPointsSumByUserId(Guid userId, CancellationToken cancellationToken)
    {
        return DbContext.ResearchTaskEffects
            .Where(researchTaskEffect =>
                researchTaskEffect.FormC.CruiseApplication.FormA!.CruiseManagerId == userId ||
                researchTaskEffect.FormC.CruiseApplication.FormA.DeputyManagerId == userId)
            .Select(researchTaskEffect => researchTaskEffect.Points)
            .SumAsync(cancellationToken);
    }
}