using Microsoft.EntityFrameworkCore;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Infrastructure.Persistence.Repositories;

internal class UserPublicationsRepository : Repository<UserPublication>, IUserPublicationsRepository
{
    public UserPublicationsRepository(ApplicationDbContext dbContext) : base(dbContext)
    { }

    public Task<List<UserPublication>> GetAllByUserId(Guid userId, CancellationToken cancellationToken)
    {
        return DbContext.UserPublications
            .Include(userPublication => userPublication.Publication)
            .Where(publication => publication.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public bool CheckIfExists(Publication publication)
    {
        var list = DbContext.UserPublications
            .Include(userPublication => userPublication.Publication)
            .ToList();
        var temp = false;
        list.ForEach(userPublication =>
        {
            if (userPublication.Publication.Equals(publication))
                temp = true;
        });
        return temp;
    }
    
    public void Delete(UserPublication userPublication)
    {
        DbContext.UserPublications.Remove(userPublication);
        DbContext.SaveChanges();
    }
}