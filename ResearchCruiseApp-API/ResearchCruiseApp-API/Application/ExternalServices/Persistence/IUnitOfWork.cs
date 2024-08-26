﻿using System.Data;

namespace ResearchCruiseApp_API.Application.ExternalServices.Persistence;


public interface IUnitOfWork
{
    Task Complete(CancellationToken cancellationToken);
    Task ExecuteIsolated(
        Func<Task> action, IsolationLevel isolationLevel, CancellationToken cancellationToken);
    Task<TResult> ExecuteIsolated<TResult>(
        Func<Task<TResult>> action, IsolationLevel isolationLevel, CancellationToken cancellationToken);
}