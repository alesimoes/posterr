using As.Posterr.Application.Contracts.Posts;
using As.Posterr.Application.Contracts.Profiles;
using As.Posterr.Application.EventHandlers;
using As.Posterr.Application.UseCases;
using As.Posterr.Domain;
using As.Posterr.EventPublisher;
using FluentMediator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As.Posterr.Api.Configuration
{
    public static class AddEventsConfiguration
    {
        public static IServiceCollection AddEvents(this IServiceCollection services)
        {
            services.AddScoped<IEventService,EventService>();
            services.AddScoped<PostCreatedEventHandler>();
            return services;
        }
    }
}
