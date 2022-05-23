using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Events
{
    public abstract class DomainEvent
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}
