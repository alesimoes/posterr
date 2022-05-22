using As.Posterr.Application.Contracts.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Application.Contracts.Profiles
{
    public class ProfileResponse
    {
        public string ProfileId { get; internal set; }
        public string Username { get; internal set; }
        public int FollowersCount { get; internal set; }
        public int FollowingCount { get; internal  set; }
        public int PostsCount { get; internal set; }
        public List<PostResponse> LatestPosts { get; internal set; }
        public string DateJoined { get; internal set; }
        public bool? Following { get; internal set; }
        public bool IsLoggedUser { get; internal set; }
     
    }
}
