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

namespace As.Posterr.Test
{
    [TestClass]
    public class FollowProfileUseCaseTest
    {
        private Mock<IProfileRepository> _profileRepository;
        private Mock<ISecurityService> _securityService;
        private Mock<IFollowRepository> _followRepository;
        private Mock<IPostRepository> _postRepository;
        private Mock<IEventService> _eventService;
        private ProfileService _profileService;
        private FollowProfileUseCase _useCase;

        public FollowProfileUseCaseTest()
        {
            _profileRepository = _profileRepository.Build();
            _followRepository = _followRepository.Build();
            _eventService = _eventService.Build();
            _postRepository = _postRepository.Build();
            _securityService = _securityService.Build();

            _profileService = new ProfileService(_profileRepository.Object, _securityService.Object, _followRepository.Object, _postRepository.Object, _eventService.Object);
            _useCase = new FollowProfileUseCase(_profileService);
        }

        [TestMethod]
        public async Task Execute_WhenIsOk_ReturnOk()
        {
            var request = new FollowProfileRequest
            {
                ProfileId = System.Guid.Parse("8E955438-E33E-45FF-BDEE-54E7AA74464A")
            };

            await _useCase.Execute(request);
        }

        [TestMethod]
        [ExpectedException(typeof(UserAlreadyFollowingException))]
        public async Task Execute_WhenAlreadyFollowing_ReturnUserAlreadyFollowingException()
        {
            var request = new FollowProfileRequest
            {
                ProfileId = System.Guid.Parse("d3aeeab9-c3ce-43ce-8668-3f5eb984f6c7")
            };

            await _useCase.Execute(request);
        }

        [TestMethod]
        [ExpectedException(typeof(UserCannotFollowThemselvesException))]
        public async Task Execute_WhenFollowLeggedInUser_ReturnUserCannotFollowThemselvesException()
        {
            var request = new FollowProfileRequest
            {
                ProfileId = System.Guid.Parse("0769c29c-5d71-49c8-8685-08ab1bf0b922")
            };

            await _useCase.Execute(request);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public async Task Execute_WhenInvalidUser_ReturnNotFoundException()
        {
            var request = new FollowProfileRequest
            {
                ProfileId = System.Guid.Parse("F95F3F67-CCAF-4E98-A06C-D885178686CA")
            };

            await _useCase.Execute(request);
        }
    }
}
