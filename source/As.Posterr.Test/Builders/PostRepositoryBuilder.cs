using As.Posterr.Domain;
using As.Posterr.Domain.Posts;
using As.Posterr.Domain.Profiles;
using As.Posterr.Domain.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Test.Builders
{
    public static class PostRepositoryBuilder
    {
        public static Mock<IPostRepository> Build(this Mock<IPostRepository> mock)
        {
            mock = new Mock<IPostRepository>();
            mock.Setup(f => f.Find(Guid.Parse("C1DDDD4F-7F9F-47D4-8F36-12518F197DCB"))).ReturnsAsync(new Post("text", new Profile(Guid.Parse("0769c29c-5d71-49c8-8685-08ab1bf0b922"), Guid.Parse("e9f03e73-f8da-4807-b744-88d21cbee311"),"test1"),null));

            var posts = new List<Post>();
            posts.Add(new Post("text", new Profile(Guid.Parse("0769c29c-5d71-49c8-8685-08ab1bf0b922"), Guid.Parse("e9f03e73-f8da-4807-b744-88d21cbee311"), "test1"), null));
            mock.Setup(f => f.FilterProfilePosts(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>())).Returns(posts);
           
            mock.Setup(f => f.FilterAllPosts(It.IsAny<int>(), It.IsAny<int>())).Returns(posts);
            mock.Setup(f => f.FilterFollowingPosts(Guid.Parse("0769c29c-5d71-49c8-8685-08ab1bf0b922"), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(posts);
            return mock;
        } 
    }
}
