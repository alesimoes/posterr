using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Application.Contracts.Posts
{
    public class PostResponse
    {
        public Guid Id { get; internal set; }
        public string Text { get; internal set; }
        public bool IsQuotedPost { get; internal set; }
        public DateTime DateCreated { get; internal set; }
        public PostResponse Repost { get; internal set; }
    }
}
