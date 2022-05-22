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
    public class GetProfileUseCaseTest
    {
        private Mock<IProfileRepository> _profileRepository;
        private Mock<ISecurityService> _securityService;
        private Mock<IFollowRepository> _followRepository;
        private Mock<IEventService> _eventService;
        private GetProfileUseCase _useCase;

        public GetProfileUseCaseTest()
        {
            _profileRepository = _profileRepository.Build();
            _followRepository = _followRepository.Build();
            _eventService = _eventService.Build();
            _securityService = _securityService.Build();

            _useCase = new GetProfileUseCase(_profileRepository.Object, _securityService.Object);
        }

        [TestMethod]
        public async Task Execute_WhenIdIsEmpty_ReturnLoggedUserProfile()
        {
            var request = new GetProfileRequest
            {  
            };

            var profile = await _useCase.Execute(request);

            Assert.IsTrue(profile.IsLoggedUser);
        }

        [TestMethod]
        public async Task Execute_WhenProfileId_ReturnProfile()
        {
            var request = new GetProfileRequest
            {
                ProfileId = System.Guid.Parse("8E955438-E33E-45FF-BDEE-54E7AA74464A")
            };

            var profile = await _useCase.Execute(request);
            Assert.IsFalse(profile.IsLoggedUser);
        }
    }
}
