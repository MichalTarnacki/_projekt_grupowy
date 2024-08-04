﻿using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.ServicesInterfaces.Persistence.Repositories;


public interface IFormsARepository : IRepository<FormA>
{
    Task AddFormA(FormA formA, CancellationToken cancellationToken);
}