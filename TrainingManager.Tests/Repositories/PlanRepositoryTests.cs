using FluentAssertions;
using TrainingManager.Models;
using TrainingManager.Repositories;
using TrainingManager.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;

namespace TrainingManager.Tests.Repositories
{

    [TestClass]
    public class PlanRepositoryTests
    {
        private PlanRepository _repository;
        private Mock<DbSet<Plan>> _mockPlans;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockPlans = new Mock<DbSet<Plan>>();

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.SetupGet(c => c.Plans).Returns(_mockPlans.Object);

            _repository = new PlanRepository(mockContext.Object);
        }

        [TestMethod]
        public void GetPlan_PlanIsRemoved_ShouldBeEmpty()
        {
            var plan = new Plan { Id = 1 };
            plan.Remove();

            _mockPlans.SetSource(new[] { plan });

            var plans = _repository.GetPlan(1);

            plans.Should().BeNull();
        }

        [TestMethod]
        public void GetPlan_ValidRequest_ShouldBeReturned()
        {
            var plan = new Plan { Id = 1 };

            _mockPlans.SetSource(new[] { plan });

            var plans = _repository.GetPlan(1);

            plans.Should().Be(plan);
        }
    }
}
