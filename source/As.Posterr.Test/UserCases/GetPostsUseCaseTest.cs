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
    public class GetPostsUseCaseTest
    {
        private Mock<IProfileRepository> _profileRepository;
        private Mock<ISecurityService> _securityService;
        private Mock<IFollowRepository> _followRepository;
        private Mock<IPostRepository> _postRepository;
        private Mock<IEventService> _eventService;
        private GetPostsUseCase _useCase;

        public GetPostsUseCaseTest()
        {
            _profileRepository = _profileRepository.Build();
            _followRepository = _followRepository.Build();
            _postRepository = _postRepository.Build();
            _eventService = _eventService.Build();
            _securityService = _securityService.Build();

            _useCase = new GetPostsUseCase(_postRepository.Object, _profileRepository.Object, _securityService.Object);
        }

        [TestMethod]
        public async Task Execute_WhenAll_ReturnAllPosts()
        {
            var request = new GetPostsRequest
            {
                All = true
            };

            var posts = await _useCase.Execute(request);
            Assert.IsNotNull(posts);
        }

        [TestMethod]
        public async Task Execute_WhenNosAll_ReturnPostsFromFollowingProfile()
        {
            var request = new GetPostsRequest
            {   
            };

            var posts = await _useCase.Execute(request);
            Assert.IsNotNull(posts);
        }
    }
}
