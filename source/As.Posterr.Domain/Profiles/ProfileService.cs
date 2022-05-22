using As.Posterr.Domain.Exceptions;
using As.Posterr.Domain.Follows;
using As.Posterr.Domain.Posts;
using As.Posterr.Domain.Profiles.Events;
using As.Posterr.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Profiles
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _repository;
        private readonly ISecurityService _securityService;
        private readonly IEventService _eventService;
        private readonly IPostRepository _postRepository;
        private readonly IFollowRepository _followRepository;

        public ProfileService(IProfileRepository repository,
            ISecurityService securityService,
            IFollowRepository followRepository,
            IPostRepository postRepository,
            IEventService eventService
            )
        {
            _repository = repository;
            _securityService = securityService;
            _eventService = eventService;
            _postRepository = postRepository;
            _followRepository = followRepository;
        }

        public async Task UpdateProfilePosts(Post post)
        {
            var profile = await _repository.Get(post.ProfileId);
            var todayPosts = profile.LatestPosts.Where(c => c.CreatedDate.Date == DateTime.UtcNow.Date);
            if (todayPosts.Count() > 4)
            {
                _postRepository.Delete(post);
                throw new LimitPostsExceededException(5);
            }

            profile.UpdatePosts(post);
            _eventService.Events.Add(new ProfileUpdatedEvent(profile));
            await _repository.Update(profile);
            await _eventService.Publish();
        }

        public async Task FollowProfile(Guid profileId)
        {
            var profileFollow = await _repository.Get(profileId);
            if (profileFollow == null)
            {
                throw new NotFoundException(Fields.Profile);
            }

            var profile = await _repository.GetByUserId(_securityService.LoggedUser.Id);
            var follow = await _followRepository.Find(profileFollow.Id, profile.Id);

            if (profileFollow.Id == profile.Id)
            {
                throw new UserCannotFollowThemselvesException();
            }

            if (follow != null)
            {
                throw new UserAlreadyFollowingException();
            }

            follow = new Follow(profileFollow.Id, profile.Id);
            profile.Follow();
            profileFollow.AddFollowers();

            _eventService.Events.Add(new ProfileUpdatedEvent(profile));

            await _repository.Update(profile);
            await _repository.Update(profileFollow);
            await _followRepository.Add(follow);
            await _eventService.Publish();
        }

        public async Task UnfollowProfile(Guid profileId)
        {
            var profileFollow = await _repository.Get(profileId);
            if (profileFollow == null)
            {
                throw new NotFoundException(Fields.Profile);
            }

            var profile = await _repository.GetByUserId(_securityService.LoggedUser.Id);
            var follow = await _followRepository.Find(profileFollow.Id, profile.Id);
            if (follow == null)
            {
                throw new NotFollowingTheUserException();
            }

            await _followRepository.Delete(follow);
            profile.UnFollow();
            profileFollow.RemoveFollowers();

            _eventService.Events.Add(new ProfileUpdatedEvent(profile));
            await _repository.Update(profile);
            await _repository.Update(profileFollow);
            await _eventService.Publish();
        }
    }
}
