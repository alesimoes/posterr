using As.Posterr.Domain;
using As.Posterr.Domain.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Test.Builders
{
    public static class SecurityServiceBuilder
    {
        public static Mock<ISecurityService> Build(this Mock<ISecurityService> mock)
        {
            mock = new Mock<ISecurityService>();
            mock.Setup(f => f.LoggedUser).Returns(new User(Guid.Parse("E9F03E73-F8DA-4807-B744-88D21CBEE311")));
            return mock;
        }

        public static Mock<ISecurityService> NewUser(this Mock<ISecurityService> mock)
        {
            mock = new Mock<ISecurityService>();
            mock.Setup(f => f.LoggedUser).Returns(new User(Guid.Parse("8e955438-e33e-45ff-bdee-54e7aa74464a")));
            return mock;
        }
    }
}
