using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Infrastructure.Persistence.Repositories.Extensions;


internal static class CruiseApplicationsQueryableExtensions
{
    public static IIncludableQueryable<CruiseApplication, FormC?> IncludeForms(
        this IQueryable<CruiseApplication> query)
    {
        return query
            .Include(cruiseApplication => cruiseApplication.FormA)
            .Include(cruiseApplication => cruiseApplication.FormB)
            .Include(cruiseApplication => cruiseApplication.FormC);
    }

    public static IIncludableQueryable<CruiseApplication, List<SpubTask>> IncludeFormAContent(
        this IQueryable<CruiseApplication> query)
    {
        throw new NotImplementedException();
        // return query
        //     .Include(cruiseApplication => cruiseApplication.FormA!.Contracts)
        //     .Include(cruiseApplication => cruiseApplication.FormA!.FormAPublications)
        //     .Include(cruiseApplication => cruiseApplication.FormA!.FormAGuestUnits)
        //     .Include(cruiseApplication => cruiseApplication.FormA!.FormAResearchTasks)
        //     .Include(cruiseApplication => cruiseApplication.FormA!.FormAUgUnits)
        //     .Include(cruiseApplication => cruiseApplication.FormA!.FormASpubTasks);
    }
}