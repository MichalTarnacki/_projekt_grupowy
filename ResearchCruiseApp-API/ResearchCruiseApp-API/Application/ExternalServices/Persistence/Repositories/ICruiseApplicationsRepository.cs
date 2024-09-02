using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;


public interface ICruiseApplicationsRepository : IRepository<CruiseApplication>
{
    Task<List<CruiseApplication>> GetAllWithForms(CancellationToken cancellationToken);
    Task<CruiseApplication?> GetByIdWithForms(Guid id, CancellationToken cancellationToken);
    Task<CruiseApplication?> GetByIdWithFormAContent(Guid id, CancellationToken cancellationToken);
    Task<List<CruiseApplication>> GetManyByIds(List<Guid> ids, CancellationToken cancellationToken);
    Task<FormA?> GetFormAByCruiseApplicationId(Guid id, CancellationToken cancellationToken);
}