using As.Posterr.Application.Contracts.Posts;
using As.Posterr.Application.Contracts.Profiles;
using As.Posterr.Domain.Profiles;
using As.Posterr.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Application.UseCases
{
    public class GetProfileUseCase
    {
        private readonly IProfileRepository _repository;
        private readonly ISecurityService _securityService;

        public GetProfileUseCase(IProfileRepository repository, ISecurityService securityService)
        {
            _repository = repository;
            _securityService = securityService;
        }

        public async Task<ProfileResponse> Execute(GetProfileRequest request)
        {
            var currentUserProfile = await _repository.GetByUserId(_securityService.LoggedUser.Id);
            
            if (!request.ProfileId.HasValue)
            {
                return currentUserProfile.ToResponse(false, true);
            }

            var profile = await _repository.Get(request.ProfileId.Value);
            var following = await _repository.GetFollowing(profile.Id, currentUserProfile.Id);

            return profile.ToResponse(following != null, following?.Id == currentUserProfile.Id);
        }
    }
}
