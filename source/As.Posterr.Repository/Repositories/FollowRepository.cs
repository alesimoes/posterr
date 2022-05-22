using As.Posterr.Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using As.Posterr.Domain.Profiles;
using As.Posterr.Domain.Follows;

namespace As.Posterr.Repositories.MongoDB
{
    public class FollowRepository : IFollowRepository
    {
        private readonly MongoDbContext _context;

        public FollowRepository(MongoDbContext _context)
        {
            this._context = _context;
        }

        public async Task Add(Follow follow)
        {
            await _context.Follows.InsertOneAsync(follow);
        }

        public async Task Delete(Follow follow)
        {
            await _context.Follows.DeleteOneAsync(f=>f.Followed == follow.Followed && f.Following == follow.Following);
        }

        public async Task<Follow> Find(Guid following, Guid followed)
        {
            return (await _context.Follows.FindAsync(f=>f.Followed == followed && f.Following == following)).FirstOrDefault();
        }
      
    }
}
