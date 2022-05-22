using As.Posterr.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Test.Builders
{
    public static class EventServiceBuilder
    {
        public static Mock<IEventService> Build(this Mock<IEventService> mock)
        {
            mock = new Mock<IEventService>();
            mock.Setup(f => f.Events).Returns(new System.Collections.Generic.List<Domain.Events.DomainEvent>());
            return mock;
        } 
    }
}
