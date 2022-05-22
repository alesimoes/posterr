using As.Posterr.Application.Contracts.Posts;
using As.Posterr.Domain.Posts;
using As.Posterr.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Application.UseCases
{
    public class PostUseCase
    {
        private IPostService _postService;

        public PostUseCase(IPostService postService)
        {
            _postService = postService;
        }

        public async Task Execute(PostRequest request)
        {
            await _postService.Post(request.Text, request.PostId);
        }
    }
}
