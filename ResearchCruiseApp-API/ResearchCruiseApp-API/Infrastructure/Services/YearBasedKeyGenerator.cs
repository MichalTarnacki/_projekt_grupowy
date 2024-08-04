using ResearchCruiseApp_API.Application.ServicesInterfaces;
using ResearchCruiseApp_API.Application.ServicesInterfaces.Persistence.Repositories;
using ResearchCruiseApp_API.Domain.Common.Interfaces;

namespace ResearchCruiseApp_API.Infrastructure.Services;


public class YearBasedKeyGenerator : IYearBasedKeyGenerator
{
    public async Task<string> GenerateKey<T>(IRepository<T> repository, CancellationToken cancellationToken)
        where T : IYearBasedNumberedEntity
    {
        var currentYear = DateTime.Now.Year.ToString();
        var ordinalNumberStartIdx = currentYear.Length + 1;
        var entities = await repository.GetList(cancellationToken);
        var maxCurrentYearOrdinalNumber = entities
            .Where(e => e.Number.StartsWith(currentYear))
            .MaxBy(e => e.Number[ordinalNumberStartIdx..])?
            .Number[ordinalNumberStartIdx..] ?? "0";

        return $"{currentYear}/{int.Parse(maxCurrentYearOrdinalNumber) + 1}";
    }
}