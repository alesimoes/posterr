using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Follows
{
    public interface IFollowRepository
    {
        Task<Follow> Find(Guid following, Guid followed);
        Task Add(Follow follow);
        Task Delete(Follow follow);
    }
}
