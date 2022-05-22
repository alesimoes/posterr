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
    public class GetFollowersUseCase
    {
        private readonly IProfileRepository _profileRepository;
        private readonly ISecurityService _securityService;

        public GetFollowersUseCase(
            IProfileRepository profileRepository,
            ISecurityService securityService)
        {
            _profileRepository = profileRepository;
            _securityService = securityService;
        }

        public async Task<List<ProfileResponse>> Execute(GetFollowersRequest request)
        {
            var currentUserProfile = await _profileRepository.GetByUserId(_securityService.LoggedUser.Id);
            if (!request.ProfileId.HasValue)
            {  
                request.ProfileId = currentUserProfile.Id;
            }

            var followers  = await _profileRepository.GetFollowers(request.ProfileId.GetValueOrDefault(), request.Index, 10);
            return followers.Select(f => f.ToResponse(null, currentUserProfile.Id == f.Id)).ToList();
        }
    }
}
