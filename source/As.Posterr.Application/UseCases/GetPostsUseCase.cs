using As.Posterr.Application.Contracts.Posts;
using As.Posterr.Domain.Posts;
using As.Posterr.Domain.Profiles;
using As.Posterr.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Application.UseCases
{
    public class GetPostsUseCase
    {
        private readonly IPostRepository _repository;
        private readonly IProfileRepository _profileRepository;
        private readonly ISecurityService _securityService;

        public GetPostsUseCase(IPostRepository repository,
            IProfileRepository profileRepository,
            ISecurityService securityService)
        {
            _repository = repository;
            _profileRepository = profileRepository;
            _securityService = securityService;
        }

        public async Task<List<PostResponse>> Execute(GetPostsRequest request)
        {
            List<Post> posts;
            if (request.All)
            {
                posts = _repository.FilterAllPosts(request.Index, 10);
            }
            else
            {
                var profile = await _profileRepository.GetByUserId(_securityService.LoggedUser.Id);
                posts = await _repository.FilterFollowingPosts(profile.Id, request.Index, 10);
            }
            return posts.Select(p => p.ToResponse()).ToList();
        }
    }
}
