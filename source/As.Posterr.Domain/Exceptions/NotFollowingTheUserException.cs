using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Exceptions
{
    public class NotFollowingTheUserException : DomainException
    {
        public NotFollowingTheUserException() : base(string.Format(Messages.NotFollowingTheUser))
        {
        }
    }
}
