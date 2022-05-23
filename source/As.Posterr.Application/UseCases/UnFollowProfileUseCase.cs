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
    public class UnFollowProfileUseCase
    {
        private readonly IProfileService _service;
        
        public UnFollowProfileUseCase(IProfileService service)
        {
            _service = service;
        }

        public async Task Execute(UnFollowProfileRequest request)
        {
            await _service.UnfollowProfile(request.ProfileId);
        }
    }
}
