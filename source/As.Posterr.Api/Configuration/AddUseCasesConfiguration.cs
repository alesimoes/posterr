using As.Posterr.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As.Posterr.Api.Configuration
{
    public static class AddUseCasesConfiguration
    {
        public static IServiceCollection AddUseCases(
           this IServiceCollection services)
        {

            services.AddScoped<FollowProfileUseCase>();
            services.AddScoped<GetFollowersUseCase>();
            services.AddScoped<GetFollowingUseCase>();
            services.AddScoped<GetPostsUseCase>();
            services.AddScoped<GetProfilePostsUseCase>();
            services.AddScoped<GetProfileUseCase>();
            services.AddScoped<PostUseCase>();
            services.AddScoped<UnFollowProfileUseCase>();
            services.AddScoped<GetSearchPostsUseCase>();
            return services;
        }
    }
}
