using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Users
{
    public class SecurityService : ISecurityService
    {
        public User LoggedUser { get; set; }
    }
}
