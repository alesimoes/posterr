using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Exceptions
{
    public class InvalidPostException : DomainException
    {
        public InvalidPostException() : base(string.Format(Messages.InvalidPost))
        {
        }
    }
}
