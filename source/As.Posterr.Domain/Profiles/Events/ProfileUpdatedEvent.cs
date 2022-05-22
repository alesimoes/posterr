using As.Posterr.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Profiles.Events
{
    public class ProfileUpdatedEvent : DomainEvent
    {
        public Profile Profile { get; }

        public ProfileUpdatedEvent(Profile post)
        {
            this.Profile = post;
        }
    }
}
