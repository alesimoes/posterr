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
    public class GetFollowingUseCase
    {
        private readonly IProfileRepository _profileRepository;
        private readonly ISecurityService _securityService;

        public GetFollowingUseCase(
            IProfileRepository profileRepository,
            ISecurityService securityService)
        {
            _profileRepository = profileRepository;
            _securityService = securityService;
        }

        public async Task<List<ProfileResponse>> Execute(GetFollowingRequest request)
        {
            var currentUserProfile = await _profileRepository.GetByUserId(_securityService.LoggedUser.Id);
            var following  = await _profileRepository.GetFollowing(request.ProfileId, request.Index, 10);
            return following.Select(f => f.ToResponse(true, currentUserProfile.Id == f.Id)).ToList();
        }
    }
}
