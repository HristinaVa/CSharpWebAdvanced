﻿using KindergartenSystem.Data.Models;
using KindergartenSystem.Web.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using static KindergartenSystem.Common.GeneralApplicationConstants;

namespace KindergartenSystem.Web.Infrastructure.Extensions
{
    public static class WebApplicationBuilderExtensions
    {

        /// <summary>
        /// This method registers all services with their interfaces and implementations of given assembly.
        /// The assembly is taken from the type of random service interface or implementation provided.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provided!");
            }

            Type[] implementationTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();
            foreach (Type implementationType in implementationTypes)
            {
                Type? interfaceType = implementationType
                    .GetInterface($"I{implementationType.Name}");
                if (interfaceType == null)
                {
                    throw new InvalidOperationException(
                        $"No interface is provided for the service with name: {implementationType.Name}");
                }

                services.AddScoped(interfaceType, implementationType);
            }
        }
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder application, string email)
        {
            using var scopedServices = application.ApplicationServices.CreateScope();
            IServiceProvider serviceProvider = scopedServices.ServiceProvider;
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    return;
                }

                IdentityRole role =
                    new IdentityRole(AdminRoleName);

                await roleManager.CreateAsync(role);

                ApplicationUser adminUser =
                    await userManager.FindByEmailAsync(email);

                await userManager.AddToRoleAsync(adminUser, AdminRoleName);
            })
            .GetAwaiter()
            .GetResult();

            return application;
        }
        public static IApplicationBuilder EnableOnlineUsersCheck(this IApplicationBuilder app)
        {
            return app.UseMiddleware<OnlineUsersMiddleware>();
        }
        

    }
}
