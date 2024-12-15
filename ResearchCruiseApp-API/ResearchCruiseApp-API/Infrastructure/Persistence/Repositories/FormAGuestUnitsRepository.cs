﻿using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Infrastructure.Persistence.Repositories;


internal class FormAGuestUnitsRepository : Repository<FormAGuestUnit>, IFormAGuestUnitsRepository
{
    public FormAGuestUnitsRepository(ApplicationDbContext dbContext) : base(dbContext)
    { }
}