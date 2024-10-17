using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;


public interface IUserEffectsRepository : IRepository<UserEffect>
{
    Task<int> GetPointsSumByUserId(Guid userId, CancellationToken cancellationToken);
}