namespace ResearchCruiseApp_API.Application.ServicesInterfaces.Persistence.Repositories;


public interface IRepository<T>
{
    Task<List<T>> GetList(CancellationToken cancellationToken);
}