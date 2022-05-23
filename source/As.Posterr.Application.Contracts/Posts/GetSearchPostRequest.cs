using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Application.Contracts.Posts
{
    public class GetSearchPostRequest
    {
        public string Text { get; set; }
        public int Index { get; set; }
    }
}
