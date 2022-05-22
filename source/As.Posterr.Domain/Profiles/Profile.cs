using As.Posterr.Domain;
using As.Posterr.Domain.Posts;
using As.Posterr.Domain.Users;
using As.Posterr.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Profiles
{
    public class Profile
    {
        public Guid Id { get; protected set; }
        public Username Username { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; protected set; }
        public int FollowersCount { get; protected set; }
        public int FollowingCount { get; protected set; }
        public int PostsCount { get; protected set; }
        public List<Post> LatestPosts { get; protected internal set; }
        
        public Profile(Guid id, Guid userId, string username)
        {
            this.Id = id;
            this.UserId = userId;
            this.Username = new Username(username);
            this.FollowersCount = 0;
            this.FollowingCount = 0;
            this.PostsCount = 0;
            this.LatestPosts = new List<Post>();
            this.CreatedDate = DateTime.UtcNow;
        }

        internal void UpdatePosts(Post post)
        {
            if(this.LatestPosts == null)
            {
                this.LatestPosts = new List<Post>();
            }
            this.PostsCount++;
            this.LatestPosts.Add(post);
            this.LatestPosts = this.LatestPosts.Take(5).ToList();
        }

        internal void Follow()
        {
            this.FollowingCount++;
        }

        internal void UnFollow()
        {
            this.FollowingCount--;
        }

        internal void AddFollowers()
        {
            this.FollowersCount++;
        }
        internal void RemoveFollowers()
        {
            this.FollowersCount--;
        }
    }
}
