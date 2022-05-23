using As.Posterr.Application.UseCases;
using As.Posterr.Domain.Posts;
using As.Posterr.Domain.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As.Posterr.Api.Configuration
{
    public static class AddServicesConfiguration
    {
        public static IServiceCollection AddServices(
           this IServiceCollection services)
        {

            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IPostService, PostService>();
            return services;
        }
    }
}
