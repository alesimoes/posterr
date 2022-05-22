using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Exceptions
{
    public class NotFoundException : DomainException
    {
        public NotFoundException(string entity) : base(string.Format(Messages.NotFound,entity))
        {
        }
    }
}
