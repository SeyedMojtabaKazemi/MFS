using MFS.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFS.Endpoint.WebAPI.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void CustomExcpetionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static void AddServiceRegistry(this IServiceCollection services)
        {
            services.Scan(scan => scan
                    .FromCallingAssembly() // 1. Find the concrete classes
                    .AddClasses()        //    to register
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip) // 2. Define how to handle duplicates
                    .AsImplementedInterfaces()    // 2. Specify which services they are registered as implemented interfaces
                    .WithScopedLifetime());// 3. Set the lifetime for the services
        }

        public static async Task EnsureDb(this IServiceProvider service)
        {
            using var db = service.CreateScope().ServiceProvider.GetRequiredService<MFSContext>();
            if (db.Database.IsRelational())
            {
                await db.Database.MigrateAsync();
            }
            //await db.Database.EnsureCreatedAsync();
        }
    }
}
