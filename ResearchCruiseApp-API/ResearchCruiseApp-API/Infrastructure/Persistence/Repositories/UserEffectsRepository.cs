﻿using Microsoft.EntityFrameworkCore;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Infrastructure.Persistence.Repositories;


internal class UserEffectsRepository : Repository<UserEffect>, IUserEffectsRepository
{
    public UserEffectsRepository(ApplicationDbContext dbContext) : base(dbContext)
    { }


    public Task<List<UserEffect>> GetAllByUserIdWithCruiseApplication(Guid userId, CancellationToken cancellationToken)
    {
        return DbContext.UserEffects
            .Include(userEffect => userEffect.Effect.FormC.CruiseApplication)
            .Include(userEffect => userEffect.Effect.ResearchTask)
            .Where(userEffect => userEffect.UserId == userId)
            .ToListAsync(cancellationToken);
    }
    
    public Task<int> GetPointsSumByUserId(Guid userId, CancellationToken cancellationToken)
    {
        return DbContext.UserEffects
            .Where(userEffect => userEffect.UserId == userId)
            .Select(researchTaskEffect => researchTaskEffect.Points)
            .SumAsync(cancellationToken);
    }
}