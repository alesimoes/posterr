using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Application.Contracts.Posts
{
    public class PostRequest
    {
        public string Text { get; set; }
        public Guid? PostId { get; set; }
    }
}
