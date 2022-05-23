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

namespace As.Posterr.Test
{
    [TestClass]
    public class GetFollowersUseCaseTest
    {
        private Mock<IProfileRepository> _profileRepository;
        private Mock<ISecurityService> _securityService;
        private Mock<IFollowRepository> _followRepository;
        private Mock<IPostRepository> _postRepository;
        private Mock<IEventService> _eventService;
        private GetFollowersUseCase _useCase;

        public GetFollowersUseCaseTest()
        {
            _profileRepository = _profileRepository.Build();
            _followRepository = _followRepository.Build();
            _postRepository = _postRepository.Build();
            _eventService = _eventService.Build();
            _securityService = _securityService.Build();

            _useCase = new GetFollowersUseCase(_profileRepository.Object, _securityService.Object);
        }

        [TestMethod]
        public async Task Execute_WhenProfileIdIsEmpty_ReturnFollowersFromLoggedUser()
        {
            var request = new GetFollowersRequest
            {
               
            };

            var followers = await _useCase.Execute(request);
            Assert.IsNotNull(followers);
        }

        [TestMethod]
        public async Task Execute_WhenProfileId_ReturnEmpty()
        {
            var request = new GetFollowersRequest
            {   
                ProfileId = Guid.Parse("d3aeeab9-c3ce-43ce-8668-3f5eb984f6c7")
            };

            var followers = await _useCase.Execute(request);
            Assert.AreEqual(followers.Count, 0);
        }
    }
}
