using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Follows
{
    public class Follow
    {
        public Guid Id { get; set; }
        public Guid Following { get; protected set; }
        public Guid Followed { get; protected set; }
        public DateTime CreatedDate { get; protected set; }

        internal Follow(Guid following, Guid followed)
        {
            this.Following = following;
            this.Followed = followed;
            this.CreatedDate = DateTime.UtcNow;
        }
    }
}
