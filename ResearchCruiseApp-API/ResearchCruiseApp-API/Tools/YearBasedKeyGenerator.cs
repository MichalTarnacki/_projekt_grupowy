using Microsoft.EntityFrameworkCore;
using ResearchCruiseApp_API.Data.Interfaces;

namespace ResearchCruiseApp_API.Tools;

public class YearBasedKeyGenerator : IYearBasedKeyGenerator
{
    public string GenerateKey(IQueryable<IYearBasedNumberedEntity> dbSet)
    {
        var currentYear = DateTime.Now.Year.ToString();
        var ordinalNumberStartIdx = currentYear.Length + 1;
        var entities = dbSet.ToList();
        var maxCurrentYearOrdinalNumber = entities
            .Where(e => e.Number.StartsWith(currentYear))
            .MaxBy(e => e.Number[ordinalNumberStartIdx..])?
            .Number[ordinalNumberStartIdx..] ?? "0";

        return $"{currentYear}/{int.Parse(maxCurrentYearOrdinalNumber) + 1}";
    }
}