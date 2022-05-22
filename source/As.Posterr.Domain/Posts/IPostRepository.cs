using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Posts
{
    public interface IPostRepository
    {
        Task<Post> Find(Guid postId);
        List<Post> FilterAllPosts(int pageIndex, int pageLength);
        Task<List<Post>> FilterFollowingPosts(Guid profileId, int pageIndex, int pageLength);
        Task Add(Post post);
        List<Post> FilterProfilePosts(Guid profileId, int pageIndex, int pageLength);
    }
}
