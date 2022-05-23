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
    public static class ProfileRepositoryBuilder
    {
        public static Mock<IProfileRepository> Build(this Mock<IProfileRepository> mock)
        {
            mock = new Mock<IProfileRepository>()
                .SetupLoggedUser()
                .SetupUser2Profile()
                .SetupUser1Profile()
                .SetupFollowers();

            return mock;
        }

        private static Mock<IProfileRepository> SetupFollowers(this Mock<IProfileRepository> mock)
        {
            var profiles = new List<Profile>();
            var test1Profile = new Profile(Guid.Parse("8e955438-e33e-45ff-bdee-54e7aa74464a"), Guid.Parse("8e955438-e33e-45ff-bdee-54e7aa74464a"), "testUser1");
            test1Profile.LatestPosts = new List<Domain.Posts.Post>();
            test1Profile.LatestPosts.Add(new Post("text1", test1Profile, null));
            test1Profile.LatestPosts.Add(new Post("text2", test1Profile, null));
            test1Profile.LatestPosts.Add(new Post("text3", test1Profile, null));
            test1Profile.LatestPosts.Add(new Post("text4", test1Profile, null));
            test1Profile.LatestPosts.Add(new Post("text5", test1Profile, null));
            profiles.Add(test1Profile);

            mock.Setup(f => f.GetFollowers(Guid.Parse("0769c29c-5d71-49c8-8685-08ab1bf0b922"), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(profiles);
            mock.Setup(f => f.GetFollowers(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new List<Profile>());

            mock.Setup(f => f.GetFollowing(Guid.Parse("0769c29c-5d71-49c8-8685-08ab1bf0b922"), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(profiles);
            mock.Setup(f => f.GetFollowing(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new List<Profile>());
            return mock;
        }

        private static Mock<IProfileRepository> SetupUser1Profile(this Mock<IProfileRepository> mock)
        {
            var test1Profile = new Profile(Guid.Parse("8e955438-e33e-45ff-bdee-54e7aa74464a"), Guid.Parse("8e955438-e33e-45ff-bdee-54e7aa74464a"), "testUser1");
            test1Profile.LatestPosts = new List<Domain.Posts.Post>();
            test1Profile.LatestPosts.Add(new Post("text1", test1Profile, null));
            test1Profile.LatestPosts.Add(new Post("text2", test1Profile, null));
            test1Profile.LatestPosts.Add(new Post("text3", test1Profile, null));
            test1Profile.LatestPosts.Add(new Post("text4", test1Profile, null));
            test1Profile.LatestPosts.Add(new Post("text5", test1Profile, null));

            mock.Setup(f => f.GetByUserId(Guid.Parse("8e955438-e33e-45ff-bdee-54e7aa74464a"))).ReturnsAsync(test1Profile);
            mock.Setup(f => f.Get(Guid.Parse("8e955438-e33e-45ff-bdee-54e7aa74464a"))).ReturnsAsync(test1Profile);
            return mock;
        }

        private static Mock<IProfileRepository> SetupLoggedUser(this Mock<IProfileRepository> mock)
        {
            var loggedUserProfile = new Profile(Guid.Parse("0769c29c-5d71-49c8-8685-08ab1bf0b922"), Guid.Parse("e9f03e73-f8da-4807-b744-88d21cbee311"), "loggedUser");
            mock.Setup(f => f.GetByUserId(Guid.Parse("E9F03E73-F8DA-4807-B744-88D21CBEE311"))).ReturnsAsync(loggedUserProfile);
            mock.Setup(f => f.Get(Guid.Parse("0769c29c-5d71-49c8-8685-08ab1bf0b922"))).ReturnsAsync(loggedUserProfile);
            return mock;
        }

        private static Mock<IProfileRepository> SetupUser2Profile(this Mock<IProfileRepository> mock)
        {
            mock.Setup(f => f.Get(Guid.Parse("d3aeeab9-c3ce-43ce-8668-3f5eb984f6c7"))).ReturnsAsync(new Profile(Guid.Parse("d3aeeab9-c3ce-43ce-8668-3f5eb984f6c7"), Guid.Parse("d3aeeab9-c3ce-43ce-8668-3f5eb984f6c7"), "testUser2"));
            return mock;
        }
    }
}
