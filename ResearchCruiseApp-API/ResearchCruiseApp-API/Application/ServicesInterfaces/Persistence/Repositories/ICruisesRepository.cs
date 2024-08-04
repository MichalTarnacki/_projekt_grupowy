using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.ServicesInterfaces.Persistence.Repositories;


public interface ICruisesRepository : IRepository<Cruise>
{
    Task AddCruise(Cruise cruise, CancellationToken cancellationToken);
}