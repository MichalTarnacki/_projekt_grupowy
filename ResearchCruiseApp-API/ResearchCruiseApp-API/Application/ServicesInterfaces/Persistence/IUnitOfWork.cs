using System.Data;

namespace ResearchCruiseApp_API.Application.ServicesInterfaces.Persistence;


public interface IUnitOfWork
{
    Task Complete(CancellationToken cancellationToken);

    Task ExecuteIsolated(
        Func<Task> action,
        IsolationLevel isolationLevel,
        CancellationToken cancellationToken);
}