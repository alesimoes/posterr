using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Exceptions
{
    public class NotFound : DomainException
    {
        public NotFound(string entity) : base(string.Format(Messages.NotFound,entity))
        {
        }
    }
}
