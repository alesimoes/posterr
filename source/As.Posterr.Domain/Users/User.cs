using As.Posterr.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Users
{
    public class User
    {
        public Guid Id { get; protected set; }

        public User(Guid id)
        {
            this.Id = id;
        }
    }
}
