using As.Posterr.Application.Contracts.Posts;
using As.Posterr.Domain.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Application.Contracts.Profiles
{
    public static class ProfileResponseExtension
    {
        public static ProfileResponse ToResponse(this Profile profile, bool? following = null, bool isLoggedUser = false)
        {
            return new ProfileResponse
            {
                ProfileId = profile.Id.ToString(),
                Username = profile.Username.ToString(),
                FollowersCount = profile.FollowersCount,
                FollowingCount = profile.FollowingCount,
                PostsCount = profile.PostsCount,
                LatestPosts = profile.LatestPosts.Select(p => p.ToResponse()).ToList(),
                DateJoined = profile.CreatedDate.ToLocalTime().ToString("MMMM dd, yyyy"),
                Following = following,
                IsLoggedUser = isLoggedUser
            };
        }
    }
}
