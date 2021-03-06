using As.Posterr.Application.Contracts.Posts;
using As.Posterr.Application.Contracts.Profiles;
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
    public class GetProfilePostsUseCase
    {
        private readonly IPostRepository _repository;
        private readonly IProfileRepository _profileRepository;
        private readonly ISecurityService _securityService;

        public GetProfilePostsUseCase(IPostRepository repository,
            IProfileRepository profileRepository,
            ISecurityService securityService)
        {
            _repository = repository;
            _profileRepository = profileRepository;
            _securityService = securityService;
        }

        public async Task<List<PostResponse>> Execute(GetProfilePostsRequest request)
        {
            if (!request.ProfileId.HasValue)
            {
                var currentUserProfile = await _profileRepository.GetByUserId(_securityService.LoggedUser.Id);
                request.ProfileId = currentUserProfile.Id;
            }
            var posts = _repository.FilterProfilePosts(request.ProfileId.GetValueOrDefault(), request.Index, 5);

            return posts.Select(p => p.ToResponse()).ToList();
        }
    }
}
