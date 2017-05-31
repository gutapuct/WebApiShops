using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WebApiShops.Models;

namespace WebApiShopsTests
{
    [TestClass]
    public class UnitTest1
    {
        private List<Shop> GetTestShops()
        {
            var testShops = new List<Shop>();
            testShops.Add(new Shop { Id = 1, Name = "Shop-1" });
            testShops.Add(new Shop { Id = 2, Name = "Shop-2" });
            testShops.Add(new Shop { Id = 3, Name = "Shop-3" });
            testShops.Add(new Shop { Id = 4, Name = "Shop-4" });

            return testShops;
        }

        [TestMethod]
        public void GetAllShops_ShouldReturnAllShops()
        {
            var repository = new WebApiShops.ShopsRepository();
            var controller = new WebApiShops.Controllers.ShopsController(repository);

            var result = controller.GetAll(Int32.MaxValue);
            Assert.AreEqual(repository.GetAll(Int32.MaxValue, 0).Count, result.Count);
        }

        [TestMethod]
        public void GetShop_ShouldReturnCorrectShop()
        {
            var controller = new WebApiShops.Controllers.ShopsController(new WebApiShops.ShopsRepository());

            var result = controller.GetById(2);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetShopNuber_ShouldReturnCorrectShopNumber()
        {
            var repository = new WebApiShops.ShopsRepository();
            var controller = new WebApiShops.Controllers.ShopsController(repository);

            var shops = controller.GetAll();
            var result = controller.GetById(3);

            Assert.IsInstanceOfType(System.Web.Http.act);
            //Assert.AreEqual(shops[2], result);
        }

    }
}
