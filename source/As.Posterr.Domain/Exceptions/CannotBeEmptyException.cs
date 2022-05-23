using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Exceptions
{
    public class CannotBeEmptyException : DomainException
    {
        public CannotBeEmptyException(string field) : base(string.Format(Messages.CannotBeEmpty, field.ToLower()))
        {
        }
    }
}
