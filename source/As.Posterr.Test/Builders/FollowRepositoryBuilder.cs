using As.Posterr.Domain;
using As.Posterr.Domain.Follows;
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
    public static class FollowRepositoryBuilder
    {
        public static Mock<IFollowRepository> Build(this Mock<IFollowRepository> mock)
        {
            mock = new Mock<IFollowRepository>();
            mock.Setup(f => f.Find(Guid.Parse("0769c29c-5d71-49c8-8685-08ab1bf0b922"), Guid.Parse("8e955438-e33e-45ff-bdee-54e7aa74464a"))).ReturnsAsync(new Follow(Guid.Parse("0769c29c-5d71-49c8-8685-08ab1bf0b922"), Guid.Parse("8e955438-e33e-45ff-bdee-54e7aa74464a")));
            mock.Setup(f => f.Find(Guid.Parse("0769c29c-5d71-49c8-8685-08ab1bf0b922"), Guid.Parse("0769c29c-5d71-49c8-8685-08ab1bf0b922"))).ReturnsAsync(default(Follow));
            mock.Setup(f => f.Find(Guid.Parse("8e955438-e33e-45ff-bdee-54e7aa74464a"), Guid.Parse("0769c29c-5d71-49c8-8685-08ab1bf0b922"))).ReturnsAsync(default(Follow));
            mock.Setup(f => f.Find(Guid.Parse("d3aeeab9-c3ce-43ce-8668-3f5eb984f6c7"), Guid.Parse("0769c29c-5d71-49c8-8685-08ab1bf0b922"))).ReturnsAsync(new Follow(Guid.Parse("d3aeeab9-c3ce-43ce-8668-3f5eb984f6c7"), Guid.Parse("0769c29c-5d71-49c8-8685-08ab1bf0b922")));


            return mock;
        } 
    }
}
