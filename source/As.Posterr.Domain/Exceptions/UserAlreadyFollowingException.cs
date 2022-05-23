using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Exceptions
{
    public class UserAlreadyFollowingException : DomainException
    {
        public UserAlreadyFollowingException() : base(string.Format(Messages.UserAlreadyFollowing))
        {
        }
    }
}
