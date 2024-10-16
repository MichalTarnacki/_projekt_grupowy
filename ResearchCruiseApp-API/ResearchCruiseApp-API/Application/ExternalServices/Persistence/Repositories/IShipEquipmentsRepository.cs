﻿using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;


public interface IShipEquipmentsRepository : IRepository<ShipEquipment>, IDbDictionaryRepository<ShipEquipment>;