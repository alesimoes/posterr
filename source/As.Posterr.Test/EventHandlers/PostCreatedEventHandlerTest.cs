using As.Posterr.Application.Contracts.Profiles;
using As.Posterr.Application.UseCases;
using As.Posterr.Domain.Follows;
using As.Posterr.Domain.Posts;
using As.Posterr.Domain.Profiles;
using As.Posterr.Domain.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using System;
using As.Posterr.Domain;
using As.Posterr.Test.Builders;
using As.Posterr.Domain.Exceptions;
using As.Posterr.Application.Contracts.Posts;
using As.Posterr.Application.EventHandlers;
using As.Posterr.Domain.Posts.Events;

namespace As.Posterr.Test
{
    [TestClass]
    public class PostCreatedEventHandlerTest
    {
        private Mock<IProfileRepository> _profileRepository;
        private Mock<ISecurityService> _securityService;
        private ProfileService _profileService;
        private Mock<IFollowRepository> _followRepository;
        private Mock<IPostRepository> _postRepository;
        private Mock<IEventService> _eventService;
        private PostCreatedEventHandler _eventHandler;

        public PostCreatedEventHandlerTest()
        {
            _profileRepository = _profileRepository.Build();
            _followRepository = _followRepository.Build();
            _postRepository = _postRepository.Build();
            _eventService = _eventService.Build();
            _securityService = _securityService.Build();

            _profileService = new ProfileService(_profileRepository.Object, _securityService.Object, _followRepository.Object, _eventService.Object);
            _eventHandler = new PostCreatedEventHandler(_profileService);
        }

        [TestMethod]
        public async Task Execute_WhenPostIsCreated_ReturnOk()
        {
            var loggedUserProfile = new Profile(Guid.Parse("0769c29c-5d71-49c8-8685-08ab1bf0b922"), Guid.Parse("e9f03e73-f8da-4807-b744-88d21cbee311"), "loggedUser");
            var post = new Post("New post", loggedUserProfile, null);
            var request = new PostCreatedEvent(post);

            await _eventHandler.Execute(request);
        }
    }
}
