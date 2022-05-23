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
    public class GetSearchPostUseCaseTest
    {
        private Mock<IProfileRepository> _profileRepository;
        private Mock<ISecurityService> _securityService;
        private Mock<IFollowRepository> _followRepository;
        private Mock<IPostRepository> _postRepository;
        private Mock<IEventService> _eventService;
        private GetSearchPostsUseCase _useCase;

        public GetSearchPostUseCaseTest()
        {
            _profileRepository = _profileRepository.Build();
            _followRepository = _followRepository.Build();
            _postRepository = _postRepository.Build();
            _eventService = _eventService.Build();
            _securityService = _securityService.Build();

            _useCase = new GetSearchPostsUseCase(_postRepository.Object);
        }

        [TestMethod]
        public async Task Execute_WhenValidSerch_ReturnFilteredPosts()
        {
            var request = new GetSearchPostRequest
            {
               Text = "Return"
            };

            var posts = await _useCase.Execute(request);
            Assert.IsNotNull(posts);
        }

        [TestMethod]
        public async Task Execute_WhenNoEnoughtText_ReturnEmpty()
        {
            var request = new GetSearchPostRequest
            {
                Text = "Ret"
            };

            var posts = await _useCase.Execute(request);
            Assert.AreEqual(posts.Count, 0);
        }
    }
}
