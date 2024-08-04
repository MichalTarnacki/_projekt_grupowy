﻿using System.Data;
using Microsoft.EntityFrameworkCore;
using ResearchCruiseApp_API.Application.ServicesInterfaces.Persistence;

namespace ResearchCruiseApp_API.Infrastructure.Persistence;


internal class UnitOfWork(ApplicationDbContext applicationDbContext) : IUnitOfWork
{
    public Task Complete(CancellationToken cancellationToken)
    {
        return applicationDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task ExecuteIsolated(
        Func<Task> action,
        IsolationLevel isolationLevel,
        CancellationToken cancellationToken)
    {
        await using var transaction =
            await applicationDbContext.Database.BeginTransactionAsync(isolationLevel, cancellationToken);
        try
        {
            await action();
            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}