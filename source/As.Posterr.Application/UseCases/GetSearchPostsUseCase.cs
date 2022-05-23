using As.Posterr.Application.Contracts.Posts;
using As.Posterr.Domain.Exceptions;
using As.Posterr.Domain.Posts;
using As.Posterr.Domain.Profiles;
using As.Posterr.Domain.Users;
using As.Posterr.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Application.UseCases
{
    public class GetSearchPostsUseCase
    {
        private readonly IPostRepository _repository;
     

        public GetSearchPostsUseCase(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PostResponse>> Execute(GetSearchPostRequest request)
        {
            var keywords = new TextPost(request.Text).Keywords;
            if(keywords.Count < 1)
            {
                return new List<PostResponse>();
            }
            var posts = _repository.Search(keywords, request.Index, 10);
            return posts.Select(p => p.ToResponse()).ToList();
        }
    }
}
