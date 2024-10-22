using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Infrastructure.Persistence.Repositories;


internal class ResearchEquipmentsRepository : Repository<ResearchEquipment>, IResearchEquipmentsRepository
{
    public ResearchEquipmentsRepository(ApplicationDbContext dbContext) : base(dbContext)
    { }


    /// <summary>
    /// Counts the number of associative entities between the given ResearchEquipment and any FormsC
    /// </summary>
    public async Task<int> CountFormCAssociations(
        ResearchEquipment researchEquipment, CancellationToken cancellationToken)
    {
        var researchEquipmentQuery = DbContext.ResearchEquipments
            .Where(r => r.Id == researchEquipment.Id);

        var count =
            await researchEquipmentQuery
                .SelectMany(r => r.FormCShortResearchEquipments)
                .CountAsync(cancellationToken) +
            await researchEquipmentQuery
                .SelectMany(r => r.FormCLongResearchEquipments)
                .CountAsync(cancellationToken) +
            await researchEquipmentQuery
                .SelectMany(r => r.FormCResearchEquipments)
                .CountAsync(cancellationToken);

        return count;
    }

    public async Task<int> CountUniqueFormsB(ResearchEquipment researchEquipment, CancellationToken cancellationToken)
    {
        var researchEquipmentQuery = DbContext.ResearchEquipments
            .Where(r => r.Id == researchEquipment.Id);

        var count =
            await researchEquipmentQuery
                .SelectMany(r => r.FormBShortResearchEquipments)
                .Select(fs => fs.FormB.Id)
                .Distinct()
                .CountAsync(cancellationToken) +
            await researchEquipmentQuery
                .SelectMany(r => r.FormBLongResearchEquipments)
                .Select(fl => fl.FormB.Id)
                .Distinct()
                .CountAsync(cancellationToken) +
            await researchEquipmentQuery
                .SelectMany(r => r.FormBResearchEquipments)
                .Select(fr => fr.FormB.Id)
                .Distinct()
                .CountAsync(cancellationToken);

        return count;
    }
}