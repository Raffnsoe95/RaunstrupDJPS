using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Raunstrup.Api.Controllers;
using Raunstrup.BusinessLogic.ServiceInterfaces;
using Raunstrup.DataAccess.Model;
using System;

namespace Raunstrup.UnitTest
{
    [TestClass]
    public class EmployeeUnitTest
    {
        [TestMethod]
        public void GetEmployeeTest()
        {
            var emock = new Mock<IEmployeeService>();
            var pmock = new Mock<IProjectService>();

            emock.Setup(Employee => Employee.Get(It.IsAny<int>())).Returns(new Employee
            {
                Id = 8,
                Name = "Brian"
              

            });

            var employeeController = new EmployeeController(emock.Object, pmock.Object);

            var test = employeeController.Get(8);

            Assert.AreEqual(8, test.Id);
            Assert.AreEqual("Brian", test.Name);

        }
    }
}
