using As.Posterr.Domain.Exceptions;
using As.Posterr.Domain.Posts.Events;
using As.Posterr.Domain.Profiles;
using As.Posterr.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Posts
{
    public class PostService : IPostService
    {
        private readonly ISecurityService _securityService;
        private readonly IProfileRepository _profileRepository;
        private readonly IPostRepository _repository;
        private readonly IEventService _eventService;

        public PostService(ISecurityService securityService,
            IProfileRepository profileRepository,
            IEventService eventService,
            IPostRepository repository)
        {
            _securityService = securityService;
            _profileRepository = profileRepository;
            _repository = repository;
            _eventService = eventService;
        }

        public async Task<bool> Post(string text, Guid? repostId)
        {
            Post repost = null;
            var profile = await _profileRepository.GetByUserId(_securityService.LoggedUser.Id);
            var todayPosts = profile.LatestPosts.Where(c => c.CreatedDate.Date == DateTime.UtcNow.Date);

            if (todayPosts.Count() > 4)
            {
                throw new LimitPostsExceededException(5);
            }

            if (repostId.HasValue)
            {
                repost = await _repository.Find(repostId.GetValueOrDefault());
            }

            var post = new Post(text, profile, repost);
           
            _eventService.Events.Add(new PostCreatedEvent(post));
            await _repository.Add(post);
            
            await _eventService.Publish();
            return true;
        }

    }
}
