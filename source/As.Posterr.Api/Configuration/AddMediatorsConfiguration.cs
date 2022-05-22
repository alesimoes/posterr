using As.Posterr.Application.Contracts.Posts;
using As.Posterr.Application.Contracts.Profiles;
using As.Posterr.Application.EventHandlers;
using As.Posterr.Application.UseCases;
using As.Posterr.Domain.Posts.Events;
using FluentMediator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As.Posterr.Api.Configuration
{
    public static class AddMediatorsConfiguration
    {
        public static IServiceCollection AddMediators(this IServiceCollection services)
        {
            services.AddFluentMediator(
                builder =>
                {
                    builder.On<GetPostsRequest>().PipelineAsync()
                    .Return<List<PostResponse>, GetPostsUseCase>((handler, request) => handler.Execute(request));

                    builder.On<GetProfilePostsRequest>().PipelineAsync()
                    .Return<List<PostResponse>, GetProfilePostsUseCase>((handler, request) => handler.Execute(request));

                    builder.On<PostRequest>().PipelineAsync()
                    .Call<PostUseCase>((handler, request) => handler.Execute(request));

                    builder.On<FollowProfileRequest>().PipelineAsync()
                    .Call<FollowProfileUseCase>((handler, request) => handler.Execute(request));

                    builder.On<UnFollowProfileRequest>().PipelineAsync()
                    .Call<UnFollowProfileUseCase>((handler, request) => handler.Execute(request));

                    builder.On<GetFollowersRequest>().PipelineAsync()
                    .Return<List<ProfileResponse>, GetFollowersUseCase>((handler, request) => handler.Execute(request));

                    builder.On<GetFollowingRequest>().PipelineAsync()
                    .Return<List<ProfileResponse>, GetFollowingUseCase>((handler, request) => handler.Execute(request));

                    builder.On<GetProfileRequest>().PipelineAsync()
                    .Return<ProfileResponse, GetProfileUseCase>((handler, request) => handler.Execute(request));

                    builder.On<PostCreatedEvent>().PipelineAsync()
                   .Call<PostCreatedEventHandler>((handler, request) => handler.Execute(request));

                });

            return services;
        }
    }
}
