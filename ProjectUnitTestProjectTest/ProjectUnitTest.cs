using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Raunstrup.Api.Controllers;
using Raunstrup.BusinessLogic.ServiceInterfaces;
using Raunstrup.DataAccess;
using System;

namespace RaunstrupUnitTest
{
    [TestClass]
    public class ProjectUnitTest
    {
        [TestMethod]
        public void GetProjectTestMethod()
        {
            var mock = new Mock<IProjectService>();

            mock.Setup(project => project.Get(It.IsAny<int>())).Returns(new Project
            {
                Id = 1,
                Customer = null,
                CustomerID = null,
                Active = true,
                Description = "TestTag",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                ESTdriving = 20,
                IsAccepted = false,
                IsDone = false,
                IsFixedPrice = false,
                Price = 20154
            });

            var projectController = new ProjectController(mock.Object);

            var test =  projectController.Get(1);

            Assert.AreEqual(1,test.Id);
            Assert.AreEqual(20154, test.Price);
            Assert.IsFalse(test.IsAccepted);
        }
    }
}
