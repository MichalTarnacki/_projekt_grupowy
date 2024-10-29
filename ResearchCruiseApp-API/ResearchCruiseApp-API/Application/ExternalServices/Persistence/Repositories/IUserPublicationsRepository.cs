using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;

public interface IUserPublicationsRepository : IRepository<UserPublication>
{
    Task<List<UserPublication>> GetAllByUserId(Guid userId, CancellationToken cancellationToken);

    bool CheckIfExists(Publication publication);
    
    void Delete(UserPublication userPublication);
}