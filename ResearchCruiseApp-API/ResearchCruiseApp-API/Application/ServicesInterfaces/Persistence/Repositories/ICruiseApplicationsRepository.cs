using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.ServicesInterfaces.Persistence.Repositories;


public interface ICruiseApplicationsRepository : IRepository<CruiseApplication>
{
    Task AddCruiseApplication(CruiseApplication cruiseApplication, CancellationToken cancellationToken);
}