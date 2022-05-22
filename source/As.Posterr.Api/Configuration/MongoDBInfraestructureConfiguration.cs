using As.Posterr.Domain.ValueObjects;
using As.Posterr.Repositories.MongoDB;
using As.Posterr.Repositories.MongoDB.Contexts;
using As.Posterr.Repositories.MongoDB.Serializers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As.Posterr.Api.Configuration
{
    public static class MongoDBInfraestructureConfiguration
    {

        public static IServiceCollection AddMongoDb(
          this IServiceCollection services,
          IConfiguration configuration)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer<Username>(new UsernameSerializer());
            BsonSerializer.RegisterSerializer<TextPost>(new TextPostSerializer());


            var config = new ServerConfig();
            configuration.Bind(config);
            services.AddScoped<MongoDbContext>(s => new MongoDbContext(config.MongoDB));
            return services;
        }

    }
}
