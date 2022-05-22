using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Exceptions
{
    public class UserCannotFollowThemselvesException : DomainException
    {
        public UserCannotFollowThemselvesException() : base(string.Format(Messages.UserCannotFollowThemselves))
        {
        }
    }
}
