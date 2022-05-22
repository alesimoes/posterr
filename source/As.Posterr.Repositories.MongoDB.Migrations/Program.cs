using As.Posterr.Domain.ValueObjects;
using As.Posterr.Repositories.MongoDB.Serializers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDBMigrations;
using System;

namespace As.Posterr.Repositories.MongoDB.Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer<Username>(new UsernameSerializer());
            BsonSerializer.RegisterSerializer<TextPost>(new TextPostSerializer());

            new MigrationEngine()
            .UseDatabase("mongodb://root:posterr@localhost:27018", "Posterr") //Required to use specific db
            .UseAssembly(typeof(Migration).Assembly)
            .UseSchemeValidation(false)
            .Run();
        }
    }
}
