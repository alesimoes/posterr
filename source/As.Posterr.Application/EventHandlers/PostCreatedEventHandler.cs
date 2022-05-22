using As.Posterr.Domain.Posts.Events;
using As.Posterr.Domain.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Application.EventHandlers
{
    public class PostCreatedEventHandler
    {
        private readonly IProfileService _profileService;

        public PostCreatedEventHandler(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public async Task Execute(PostCreatedEvent @event)
        {
            await _profileService.UpdateProfilePosts(@event.Post);
        }
    }
}
