using As.Posterr.Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using As.Posterr.Domain.Follows;

namespace As.Posterr.Repositories.MongoDB
{
    public class PostRepository : IPostRepository
    {
        private readonly MongoDbContext _context;

        public PostRepository(MongoDbContext _context)
        {
            this._context = _context;
        }
        public async Task Add(Post post)
        {
            await _context.Posts.InsertOneAsync(post);
        }

        public async Task<Post> Find(Guid postId)
        {
            return (await _context.Posts.FindAsync(f => f.Id == postId)).FirstOrDefault();
        }

        public async Task<List<Post>> FilterFollowingPosts(Guid profileId, int pageIndex, int pageLength)
        {
            var filterBuilder = new FilterDefinitionBuilder<Follow>();
            var filterFollowing = filterBuilder.Where(f => f.Followed == profileId);
            var following = (await _context.Follows.FindAsync(filterFollowing)).ToList()?.Select(s => s.Following).ToList();

            var filterCollection = new FilterDefinitionBuilder<Post>();
            var filter = filterCollection.In(f => f.ProfileId, following);
          
            return _context.Posts.Find(filter).SortByDescending(s => s.CreatedDate).Skip(pageIndex * pageLength).Limit(pageLength).ToList();
        }

        public List<Post> FilterAllPosts(int pageIndex, int pageLength)
        {
            return _context.Posts.Find(f => true).SortByDescending(s => s.CreatedDate).Skip(pageIndex * pageLength).Limit(pageLength).ToList();
        }

        public List<Post> FilterProfilePosts(Guid profileId, int pageIndex, int pageLength)
        {
            return _context.Posts.Find(f => f.ProfileId == profileId).SortByDescending(s => s.CreatedDate).Skip(pageIndex * pageLength).Limit(pageLength).ToList();
        }

        public void Delete(Post post)
        {
             _context.Posts.DeleteMany(d => d.Id == post.Id);
        }
    }
}
