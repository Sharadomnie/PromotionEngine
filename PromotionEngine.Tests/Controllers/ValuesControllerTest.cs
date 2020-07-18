using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;
using PromotionEngine.Controllers;
using PromotionEngine.Entity;

namespace PromotionEngine.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            IEnumerable<string> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            Sku sku = new Sku();
            sku.SkuIds = "A,A,A,A,A,A";
            sku.PromotionName = "AAA";
            // Act
            string result = controller.Post(sku);

            Assert.IsNotNull(result);
            Assert.AreEqual("260", result);    
            // Assert
        }


        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void PostNoPromotionName()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            Sku sku = new Sku();
            sku.SkuIds = "A,A,A,A,A,A";
            sku.PromotionName = "";
            // Act

            controller.Post(sku);
        }


        [TestMethod]
        public void Put()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
