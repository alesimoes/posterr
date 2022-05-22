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
    public class ProfileRepository : IProfileRepository
    {
        private readonly MongoDbContext _context;

        public ProfileRepository(MongoDbContext _context)
        {
            this._context = _context;
        }
        public async Task<Profile> Get(Guid id)
        {
            return (await _context.Profiles.FindAsync(f => f.Id == id)).FirstOrDefault();
        }

        public async Task<Profile> GetByUserId(Guid id)
        {
            return (await _context.Profiles.FindAsync(f => f.UserId == id)).FirstOrDefault();
        }

        public Task Update(Profile profile)
        {
            var updateDefinition = Builders<Profile>.Update
             .Set(u => u.FollowersCount, profile.FollowersCount)
             .Set(u => u.FollowingCount, profile.FollowingCount)
             .Set(u => u.LatestPosts, profile.LatestPosts)
             .Set(u => u.PostsCount, profile.PostsCount);

            return _context.Profiles.UpdateOneAsync(f => f.Id == profile.Id, updateDefinition);
        }

        public async Task<List<Profile>> GetFollowing(Guid profileId, int pageIndex, int pageLength)
        {
            var filterBuilder = new FilterDefinitionBuilder<Follow>();
            var filterFollowing = filterBuilder.Where(f => f.Followed == profileId);
            var following = (await _context.Follows.FindAsync(filterFollowing)).ToList()?.Select(s => s.Following).ToList();

            var filterCollection = new FilterDefinitionBuilder<Profile>();

            var filter = filterCollection.In(f => f.Id, following);

            return _context.Profiles.Find(filter).SortBy(s => s.Username.ToString()).Skip(pageIndex * pageLength).Limit(pageLength).ToList();
        }

        public async Task<List<Profile>> GetFollowers(Guid profileId, int pageIndex, int pageLength)
        {
            var filterBuilder = new FilterDefinitionBuilder<Follow>();
            var filterFollowers = filterBuilder.Where(f => f.Following == profileId);
            var followers = (await _context.Follows.FindAsync(filterFollowers)).ToList()?.Select(s => s.Followed).ToList();

            var filterCollection = new FilterDefinitionBuilder<Profile>();

            var filter = filterCollection.In(f => f.Id, followers);

            return _context.Profiles.Find(filter).SortBy(s => s.Username.ToString()).Skip(pageIndex * pageLength).Limit(pageLength).ToList();
        }

        public async Task<Profile> GetFollowing(Guid followingProfileId, Guid followerProfileId)
        {
            var filterBuilder = new FilterDefinitionBuilder<Follow>();
            var filterFollowing = filterBuilder.Where(f => f.Following == followingProfileId && f.Followed == followerProfileId);
            var following = (await _context.Follows.FindAsync(filterFollowing)).ToList()?.Select(s => s.Following).ToList();

            var filterCollection = new FilterDefinitionBuilder<Profile>();
         
            var filter = filterCollection.In(f =>f.Id, following);

            return _context.Profiles.Find(filter).FirstOrDefault();
        }
    }
}
