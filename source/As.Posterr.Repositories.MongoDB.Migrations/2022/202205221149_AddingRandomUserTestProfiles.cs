using As.Posterr.Domain.Posts;
using As.Posterr.Domain.Profiles;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using MongoDBMigrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Repositories.MongoDB.Migrations._2022
{
    public class _202205221149_AddingRandomUserTestProfiles : Migration, IMigration
    {
        public MongoDBMigrations.Version Version => new MongoDBMigrations.Version(202205, 22, 1149);

        public string Name => "Add random user tests profile";

        public void Up(IMongoDatabase database)
        {
                database.GetCollection<Profile>("Profile").InsertOneAsync(new Profile(
                  Guid.Parse("8E955438-E33E-45FF-BDEE-54E7AA74464A"),
                  Guid.Parse("8E955438-E33E-45FF-BDEE-54E7AA74464A"),
                  $"testUser1"));

            database.GetCollection<Profile>("Profile").InsertOneAsync(new Profile(
                 Guid.Parse("F0A510E8-5F5E-46DB-B493-74B2CB6441F3"),
                 Guid.Parse("F0A510E8-5F5E-46DB-B493-74B2CB6441F3"),
                 $"testUser2"));

            database.GetCollection<Profile>("Profile").InsertOneAsync(new Profile(
                 Guid.Parse("D3AEEAB9-C3CE-43CE-8668-3F5EB984F6C7"),
                 Guid.Parse("D3AEEAB9-C3CE-43CE-8668-3F5EB984F6C7"),
                 $"testUser3"));

            database.GetCollection<Profile>("Profile").InsertOneAsync(new Profile(
                 Guid.Parse("4E110349-345E-4B79-8BCB-1AFD8A9281A0"),
                 Guid.Parse("4E110349-345E-4B79-8BCB-1AFD8A9281A0"),
                 $"testUser4"));

            database.GetCollection<Profile>("Profile").InsertOneAsync(new Profile(
                 Guid.Parse("98DC0D62-4816-4ABF-A5D7-A3F4F1003CD9"),
                 Guid.Parse("98DC0D62-4816-4ABF-A5D7-A3F4F1003CD9"),
                 $"testUser5"));

        }

        public void Down(IMongoDatabase database)
        {
            database.GetCollection<Profile>("Profile").DeleteMany(f => f.Id != Guid.Parse("0769C29C-5D71-49C8-8685-08AB1BF0B922"));
        }
    }

}
