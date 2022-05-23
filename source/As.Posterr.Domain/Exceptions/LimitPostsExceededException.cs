using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Exceptions
{
    public class LimitPostsExceededException : DomainException
    {
        public LimitPostsExceededException(int limit) : base(string.Format(Messages.LimitPostsExceeded, limit))
        {
        }
    }
}
