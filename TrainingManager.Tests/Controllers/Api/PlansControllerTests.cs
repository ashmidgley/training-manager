using FluentAssertions;
using TrainingManager.Controllers.Api;
using TrainingManager.Models;
using TrainingManager.Repositories;
using TrainingManager.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace TrainingManager.Tests.Controllers.Api
{
    [TestClass]
    public class PlansControllerTests
    {
        private PlansController _controller;
        private Mock<IPlanRepository> _mockRepository;
        private string _userId = "1";
        private string _username = "user1@domain.com";

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IPlanRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Plans).Returns(_mockRepository.Object);

            _controller = new PlansController(mockUoW.Object);
            _controller.MockCurrentUser(_userId, _username);
        }

        [TestMethod]
        public void Remove_NoPlanWithGivenIdExists_ShouldReturnNotFound()
        {
            var result = _controller.Remove(1);
            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Remove_PlanIsRemoved_ShouldReturnNotFound()
        {
            var plan = new Plan { UserId = _userId };
            plan.Remove();

            _mockRepository.Setup(r => r.GetPlan(1)).Returns(plan);

            var result = _controller.Remove(1);
            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Remove_UserRemovingAnotherUsersPlan_ShouldReturnUnauthorized()
        {
            var userId = _userId + "-";
            var plan = new Plan { UserId = userId };

            _mockRepository.Setup(r => r.GetPlan(1)).Returns(plan);

            var result = _controller.Remove(1);
            result.Should().BeOfType<UnauthorizedResult>();
        }

        [TestMethod]
        public void Remove_ValidRequest_ShouldReturnOk()
        {
            var plan = new Plan { UserId = _userId };

            _mockRepository.Setup(r => r.GetPlan(1)).Returns(plan);

            var result = _controller.Remove(1);

            result.Should().BeOfType<OkResult>();
        }
    }
}
