using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Raunstrup.Api.Controllers;
using Raunstrup.BusinessLogic.ServiceInterfaces;
using Raunstrup.DataAccess;
using System;

namespace RaunstrupUnitTest
{
    [TestClass]
    public class CustomerUnitTest
    {
        [TestMethod]
        public void GetCustomerTestMethod()
        {
            var cmock = new Mock<ICustomerService>();
            var pmock = new Mock<IProjectService>();

            cmock.Setup(Customer => Customer.Get(It.IsAny<int>())).Returns(new Customer
            {
                Id = 1,
                Name="Olsen"
             
            });

            var customerController = new CustomerController(cmock.Object,pmock.Object );

            var test =  customerController.Get(1);

            Assert.AreEqual(1,test.Id);
            Assert.AreEqual("Olsen", test.Name);

        }
    }
}
