﻿using ResearchCruiseApp_API.Infrastructure.Persistence.Initialization;

namespace ResearchCruiseApp_API.Web.Configuration;


public static class WebApplicationExtensions
{
    public static async Task Configure(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app
            .UseAuthentication()
            .UseAuthorization();

        app.UseCors("CustomPolicy");

        app.MapControllers();

        await app.InitializeDatabase();
    }
}