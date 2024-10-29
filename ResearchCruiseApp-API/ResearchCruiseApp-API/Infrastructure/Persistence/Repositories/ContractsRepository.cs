﻿using Microsoft.EntityFrameworkCore;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Infrastructure.Persistence.Repositories;


internal class ContractsRepository : Repository<Contract>, IContractsRepository
{
    public ContractsRepository(ApplicationDbContext dbContext) : base(dbContext)
    { }


    public Task<int> CountFormAContracts(Contract contract, CancellationToken cancellationToken)
    {
        return DbContext.Contracts
            .Where(c => c.Id == contract.Id)
            .SelectMany(c => c.FormAContracts)
            .CountAsync(cancellationToken);
    }

    public Task<int> CountDistinctFormsC(Contract contract, CancellationToken cancellationToken)
    {
        return DbContext.Contracts
            .Where(c => c.Id == contract.Id)
            .SelectMany(c => c.FormsC)
            .Select(f => f.Id)
            .Distinct()
            .CountAsync(cancellationToken);
    }
}