﻿using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Infrastructure.Persistence.Repositories;


internal class ShipEquipmentsRepository : Repository<ShipEquipment>, IShipEquipmentsRepository
{
    public ShipEquipmentsRepository(ApplicationDbContext dbContext) : base(dbContext)
    { }
}