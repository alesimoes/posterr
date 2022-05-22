using As.Posterr.Domain.Follows;
using As.Posterr.Domain.Posts;
using As.Posterr.Domain.Profiles;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Repositories.MongoDB
{
    public class MongoDbContext : IDisposable
    {
        private readonly IMongoDatabase _db;
        private readonly IClientSessionHandle _session;
        private bool _disposed;

        public MongoDbContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
            this._session = client.StartSession();
        }
        public IMongoCollection<Post> Posts => _db.GetCollection<Post>("Post");
        public IMongoCollection<Profile> Profiles => _db.GetCollection<Profile>("Profile");
        public IMongoCollection<Follow> Follows => _db.GetCollection<Follow>("Follow");

        internal IClientSessionHandle Session => _session;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    this.Session.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
