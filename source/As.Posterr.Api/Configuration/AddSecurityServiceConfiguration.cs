using As.Posterr.Application.UseCases;
using As.Posterr.Domain.Posts;
using As.Posterr.Domain.Profiles;
using As.Posterr.Domain.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As.Posterr.Api.Configuration
{
    public static class AddSecurityServiceConfiguration
    {
        public static IServiceCollection AddSecurityService(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddScoped<ISecurityService, SecurityService>(f =>
            {
                // Mock logged-in user.
                var userIdConfig = configuration.GetSection("UserId").Value;
                var userId = Guid.Parse(userIdConfig);

                var service = new SecurityService();
                service.LoggedUser = new User(userId);
                return service;
            });
            return services;
        }
    }
}
