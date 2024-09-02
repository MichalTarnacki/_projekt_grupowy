﻿using System.Reflection;
using FluentValidation;
using ResearchCruiseApp_API.Application.Services.CruiseApplications;
using ResearchCruiseApp_API.Application.Services.Cruises;
using ResearchCruiseApp_API.Application.Services.Factories.ContractDtos;
using ResearchCruiseApp_API.Application.Services.Factories.Contracts;
using ResearchCruiseApp_API.Application.Services.Factories.CruiseApplicationDtos;
using ResearchCruiseApp_API.Application.Services.Factories.CruiseApplications;
using ResearchCruiseApp_API.Application.Services.Factories.CruiseDtos;
using ResearchCruiseApp_API.Application.Services.Factories.Cruises;
using ResearchCruiseApp_API.Application.Services.Factories.FormADtos;
using ResearchCruiseApp_API.Application.Services.Factories.FormsA;
using ResearchCruiseApp_API.Application.Services.UserPermissionVerifier;

namespace ResearchCruiseApp_API.Application;


public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        services.AddFactories();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        services
            .AddScoped<ICruisesService, CruisesService>()
            .AddScoped<ICruiseApplicationsService, CruiseApplicationsService>()
            .AddScoped<IUserPermissionVerifier, UserPermissionVerifier>();
    }


    private static void AddFactories(this IServiceCollection services)
    {
        services
            .AddScoped<IFormsAFactory, FormsAFactory>()
            .AddScoped<IFormADtosFactory, FormADtosFactory>()
            .AddScoped<IContractsFactory, ContractsFactory>()
            .AddScoped<IContractDtosFactory, ContractDtosFactory>()
            .AddScoped<ICruiseApplicationsFactory, CruiseApplicationsFactory>()
            .AddScoped<ICruiseApplicationDtosFactory, CruiseApplicationDtosFactory>()
            .AddScoped<ICruisesFactory, CruisesFactory>()
            .AddScoped<ICruiseDtosFactory, CruiseDtosFactory>();
    }
}