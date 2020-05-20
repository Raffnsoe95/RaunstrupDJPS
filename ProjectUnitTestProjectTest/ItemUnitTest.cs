using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Raunstrup.Api.Controllers;
using Raunstrup.BusinessLogic.ServiceInterfaces;
using Raunstrup.DataAccess;
using Raunstrup.DataAccess.Model;

namespace Raunstrup.UnitTest
{
    [TestClass]
    public class ItemUnitTest
    {
        [TestMethod]
        public void GetItemTestMethod() 
        {
            var mock = new Mock<IItemService>();

            mock.Setup(item => item.Get(It.IsAny<int>())).Returns(new Item
            {
                Id = 1,
                Name = "Søm",
                Price = 154,
                Active = true
            });

            var itemController = new ItemController(mock.Object);

            var test = itemController.Get(1);

            Assert.AreEqual(1, test.Id);
            Assert.AreEqual(154, test.Price);
            Assert.IsTrue(test.Active);

        }
    }
}
