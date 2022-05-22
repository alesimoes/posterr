using As.Posterr.Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Application.Contracts.Posts
{
    public static class PostResponseExtension
    {
        public static PostResponse ToResponse(this Post post)
        {
            return new PostResponse
            {
                Id = post.Id,
                IsQuotedPost = post.IsQuotePost,
                Repost = post.Repost?.ToResponse(),
                Text = post.Text.ToString(),
                DateCreated = post.CreatedDate.ToLocalTime()
            };
        }
    }
}
