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
    public class FollowProfileUseCase
    {
        private readonly IProfileService _service;
        
        public FollowProfileUseCase(IProfileService service)
        {
            _service = service;
        }

        public async Task Execute(FollowProfileRequest request)
        {
            await _service.FollowProfile(request.ProfileId);
        }
    }
}
