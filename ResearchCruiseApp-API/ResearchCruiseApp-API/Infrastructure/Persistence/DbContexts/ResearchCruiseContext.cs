﻿using Microsoft.EntityFrameworkCore;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Infrastructure.Persistence.DbContexts;


public class ResearchCruiseContext(DbContextOptions<ResearchCruiseContext> options) : DbContext(options)
{
    public DbSet<Cruise> Cruises { get; init; } = null!;
    public DbSet<Domain.Entities.Application> Applications { get; init; } = null!;
    
    public DbSet<FormA> FormsA { get; init; } = null!;
    public DbSet<FormB> FormsB { get; init; } = null!;
    public DbSet<FormC> FormsC { get; init; } = null!;

    public DbSet<ResearchTask> ResearchTasks { get; set; } = null!;
    public DbSet<Contract> Contracts { get; init; } = null!;
    public DbSet<UgTeam> UgTeams { get; init; } = null!;
    public DbSet<GuestTeam> GuestTeams { get; init; } = null!;
    public DbSet<Publication> Publications { get; init; } = null!;
    public DbSet<Thesis> Theses { get; init; } = null!;
    public DbSet<SpubTask> SpubTasks { get; init; } = null!;
    
    public DbSet<EvaluatedApplication> EvaluatedApplications { get; init; } = null!;
}