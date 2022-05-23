using As.Posterr.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain
{
    public interface IEventService
    {
        public List<DomainEvent> Events { get; set; } 

        public Task Publish();
    }
}
