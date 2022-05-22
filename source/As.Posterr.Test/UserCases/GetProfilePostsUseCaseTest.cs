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
    public class GetProfilePostsUseCaseTest
    {
        private Mock<IProfileRepository> _profileRepository;
        private Mock<ISecurityService> _securityService;
        private Mock<IFollowRepository> _followRepository;
        private Mock<IPostRepository> _postRepository;
        private Mock<IEventService> _eventService;
        private GetProfilePostsUseCase _useCase;

        public GetProfilePostsUseCaseTest()
        {
            _profileRepository = _profileRepository.Build();
            _followRepository = _followRepository.Build();
            _postRepository = _postRepository.Build();
            _eventService = _eventService.Build();
            _securityService = _securityService.Build();

            _useCase = new GetProfilePostsUseCase(_postRepository.Object, _profileRepository.Object, _securityService.Object);
        }

        [TestMethod]
        public async Task Execute_WhenIdIsEmpty_ReturnPostsFromLoggedUser()
        {
            var request = new GetProfilePostsRequest
            {  
            };

            var posts = await _useCase.Execute(request);
            Assert.IsNotNull(posts);
        }

        [TestMethod]
        public async Task Execute_WhenProfileId_ReturnPostsFromProfile()
        {
            var request = new GetProfilePostsRequest
            {
                ProfileId = System.Guid.Parse("8E955438-E33E-45FF-BDEE-54E7AA74464A")
            };

            var posts = await _useCase.Execute(request);
            Assert.IsNotNull(posts);
        }
    }
}
