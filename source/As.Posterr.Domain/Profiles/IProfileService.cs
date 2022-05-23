using As.Posterr.Domain.Posts;
using System;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Profiles
{
    public interface IProfileService
    {
        Task UpdateProfilePosts(Post post);
        Task FollowProfile(Guid profileId);
        Task UnfollowProfile(Guid profileId);
    }
}