using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Application.Contracts.Profiles
{
    public class GetFollowingRequest
    {
        public Guid? ProfileId { get; set; }
        public int Index { get; set; }
    }
}
