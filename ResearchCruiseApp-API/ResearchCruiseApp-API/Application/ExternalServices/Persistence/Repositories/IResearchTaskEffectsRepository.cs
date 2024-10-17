﻿using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;


public interface IResearchTaskEffectsRepository : IRepository<ResearchTaskEffect>
{
    Task<int> GetEffectsPointsSumByUserId(Guid userId, CancellationToken cancellationToken);
}