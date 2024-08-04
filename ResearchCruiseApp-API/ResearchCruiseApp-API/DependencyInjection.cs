using System.Reflection;
using Microsoft.AspNetCore.Identity;
using ResearchCruiseApp_API.Application.Services.Compressor;
using ResearchCruiseApp_API.Application.Services.Cruises;
using ResearchCruiseApp_API.Application.Services.UserDto;
using ResearchCruiseApp_API.Application.Services.UserPermissionVerifier;
using ResearchCruiseApp_API.Application.ServicesInterfaces;
using ResearchCruiseApp_API.Application.ServicesInterfaces.Persistence;
using ResearchCruiseApp_API.Application.ServicesInterfaces.Persistence.Repositories;
using ResearchCruiseApp_API.Domain.Entities;
using ResearchCruiseApp_API.Infrastructure.Persistence;
using ResearchCruiseApp_API.Infrastructure.Persistence.Repositories;
using ResearchCruiseApp_API.Infrastructure.Services;
using ResearchCruiseApp_API.Infrastructure.Services.Identity;

namespace ResearchCruiseApp_API;


public static class DependencyInjection
{
    public static void AddApplicationDependencies(this IServiceCollection services)
    {
        services
            .AddMediatR(cfg => 
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        services
            .AddScoped<ICompressor, Compressor>()
            .AddScoped<ICruisesService, CruisesService>()
            .AddScoped<IUserDtoService, UserDtoService>()
            .AddScoped<IUserPermissionVerifier, UserPermissionVerifier>();
    }

    public static void AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddIdentity();
        
        services
            .AddScoped<IEmailSender, EmailSender>()
            .AddScoped<IYearBasedKeyGenerator, YearBasedKeyGenerator>()
            .AddScoped<ITemplateFileReader, TemplateFileReader>();
        
        services.AddPersistence();
    }

    
    private static void AddIdentity(this IServiceCollection services)
    {
        services
            .AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);
        services
            .AddAuthorizationBuilder();

        services
            .AddIdentityCore<User>(options =>
                options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();
        
        services.AddScoped<IIdentityService, IdentityService>();
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
        });
    }

    private static void AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services
            .AddScoped<IFormsARepository, FormsARepository>()
            .AddScoped<ICruiseApplicationsRepository, CruiseApplicationsRepository>()
            .AddScoped<ICruisesRepository, CruisesRepository>();
    }
}