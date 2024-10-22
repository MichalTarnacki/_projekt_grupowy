using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;


public interface IPortsRepository : IRepository<Port>
{
    Task<int> CountFormCPorts(Port port, CancellationToken cancellationToken);

    Task<int> CountUniqueFormsB(Port port, CancellationToken cancellationToken);
}