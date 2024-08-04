using ResearchCruiseApp_API.Application.ServicesInterfaces.Persistence.Repositories;
using ResearchCruiseApp_API.Domain.Common.Interfaces;

namespace ResearchCruiseApp_API.Application.ServicesInterfaces;


public interface IYearBasedKeyGenerator
{
    Task<string> GenerateKey<T>(IRepository<T> repository, CancellationToken cancellationToken)
        where T : IYearBasedNumberedEntity;
}