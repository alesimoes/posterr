using As.Posterr.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Posts.Events
{
    public class PostCreatedEvent : DomainEvent
    {
        public Post Post { get; }

        public PostCreatedEvent(Post post)
        {
            this.Post = post;
        }
    }
}
