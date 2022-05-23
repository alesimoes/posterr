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
    public class PostUseCaseTest
    {
        private Mock<IProfileRepository> _profileRepository;
        private Mock<ISecurityService> _securityService;
        private Mock<IFollowRepository> _followRepository;
        private Mock<IPostRepository> _postRepository;
        private Mock<IEventService> _eventService;
        private PostService _postService;
        private PostUseCase _useCase;

        public PostUseCaseTest()
        {
            _profileRepository = _profileRepository.Build();
            _followRepository = _followRepository.Build();
            _eventService = _eventService.Build();
            _postRepository = _postRepository.Build();
            _securityService = _securityService.Build();

            _postService = new PostService(_securityService.Object, _profileRepository.Object, _eventService.Object, _postRepository.Object);
            _useCase = new PostUseCase(_postService);
        }

        [TestMethod]
        public async Task Execute_WhenPostIsOk_ReturnOk()
        {
            var request = new PostRequest
            {
                Text = "Test post"
            };

            await _useCase.Execute(request);
        }

        [TestMethod]
        public async Task Execute_WhenRepostIsOk_ReturnOk()
        {
            var request = new PostRequest
            {
                PostId = Guid.Parse("C1DDDD4F-7F9F-47D4-8F36-12518F197DCB")
            };

            await _useCase.Execute(request);
        }

        [TestMethod]
        public async Task Execute_WhenQuoteRepostIsOk_ReturnOk()
        {
            var request = new PostRequest
            {
                Text = "Post Ok",
                PostId = Guid.Parse("C1DDDD4F-7F9F-47D4-8F36-12518F197DCB")
            };

            await _useCase.Execute(request);
        }

        [TestMethod]
        public async Task Execute_RepostNotFoundCreateAPostOk_ReturnOk()
        {
            var request = new PostRequest
            {
                Text = "Post Ok",
                PostId = Guid.Parse("CCCE7DE5-D2BD-40DA-B050-F1D444FDEB78")
            };

            await _useCase.Execute(request);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPostException))]
        public async Task Execute_RepostNotFoundAndTextIsEmpty_ReturnNotFollowingTheUserException()
        {
            var request = new PostRequest
            {
                PostId = Guid.Parse("CCCE7DE5-D2BD-40DA-B050-F1D444FDEB78")
            };

            await _useCase.Execute(request);
        }

        [TestMethod]
        [ExpectedException(typeof(LimitPostsExceededException))]
        public async Task Execute_WhenLimitPostExceeded_ReturnLimitPostsExceededException()
        {
            _securityService = _securityService.NewUser();
            _postService = new PostService(_securityService.Object, _profileRepository.Object, _eventService.Object, _postRepository.Object);
            _useCase = new PostUseCase(_postService);

            var request = new PostRequest
            {
                PostId = Guid.Parse("CCCE7DE5-D2BD-40DA-B050-F1D444FDEB78")
            };

            await _useCase.Execute(request);
        }

        [TestMethod]
        [ExpectedException(typeof(MaximunCharactersException))]
        public async Task Execute_WhenTextLimitExceeded_ReturnNotFollowingTheUserException()
        {
            var request = new PostRequest
            {
                Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam quis ornare sapien. Sed mattis gravida justo, 
                sit amet sollicitudin ipsum molestie ac. Sed malesuada est libero, ac rutrum ligula facilisis eu. 
                Phasellus non orci sed augue convallis efficitur ac at ex. 
                Phasellus volutpat mi vel sagittis condimentum. Sed orci nulla, suscipit ac leo at, laoreet venenatis neque. Nam quis erat orci. Vivamus consectetur eu dui quis molestie.
                Nunc pulvinar suscipit justo et gravida.Sed id justo et metus bibendum eleifend.Morbi facilisis,
                est nec dignissim varius,
                neque sem finibus felis,
                at ullamcorper eros velit eu sem.Cras erat erat,
                vehicula at tempor vel,
                porttitor fringilla mi.Aliquam a dolor id nisl fringilla vulputate.Sed id dignissim est.Praesent ex risus posuere."
            };

            await _useCase.Execute(request);
        }
    }
}
