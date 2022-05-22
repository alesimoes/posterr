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
    public class _202205221029_AddingUserProfile : Migration,  IMigration
    {
        public MongoDBMigrations.Version Version => new MongoDBMigrations.Version(202205, 22, 1032);

        public string Name => "Add user profile";

        public void Up(IMongoDatabase database)
        {
            database.GetCollection<Profile>("Profile").InsertOneAsync(new Profile( 
            Guid.Parse("0769C29C-5D71-49C8-8685-08AB1BF0B922"),
            Guid.Parse("E9F03E73-F8DA-4807-B744-88D21CBEE311"),
            "alexsimoes"));
        }

        public void Down(IMongoDatabase database)
        {
            database.GetCollection<Profile>("Profile").DeleteMany(f => f.Id == Guid.Parse("0769C29C-5D71-49C8-8685-08AB1BF0B922"));
        }
    }

}
