using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dhimancars.Controllers;
using System.Web.Mvc;
using Moq;
using dhimancars.Models;
using System.Linq;

namespace dhimancars.Tests.Controllers
{
    [TestClass]
    public class StoreTest
    {
        StoreController controller;
        Mock<IIStore> mock;
        List<Store> stores;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IIStore>();

            stores = new List<Store>
            {
                new Store {CarID = 1, CarModel = "Infinity", CarYear = "2017", Price = "9000"},
                new Store {CarID = 2, CarModel = "SuperNova", CarYear = "2016", Price = "8000"},
                new Store {CarID = 3, CarModel = "Galaxy", CarYear = "2016", Price = "7000"},
                new Store {CarID = 4, CarModel = "Universe", CarYear = "2015", Price = "7000"},
                new Store {CarID = 5, CarModel = "Endless", CarYear = "2014", Price = "5000"}
            };
            // add store data to the mock object
            mock.Setup(m => m.Store).Returns(stores.AsQueryable());

            controller = new StoreController(mock.Object);
        }

        [TestMethod]
        public void IndexLoadsValid()


        {
            //StoreController controller = new StoreController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void IndexShowValidStores()
        {
            var actual = (List<Store>)controller.Index().Model;

            CollectionAssert.AreEqual(stores, actual); 
        }

        [TestMethod]
        public void DetailsValidStore()
        {
            var actual = (Store)controller.Details(1).Model;

            Assert.AreEqual(stores.ToList()[0], actual);
        }
        
        [TestMethod]
        public void DetailsInvalidId()
        {
            ViewResult actual = controller.Details(6);

            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DetailsInvalidNoId()
        {
            ViewResult actual = controller.Details(null);

            Assert.AreEqual("Error", actual.ViewName);
        }

       [TestMethod]
       public void DeleteConfirmedNoId()
        {
            ViewResult actual = controller.DeleteConfirmed(null);

            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedInvalidId()
        {
            ViewResult actual = controller.DeleteConfirmed(6);

            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedValidId()
        {
            ViewResult actual = controller.DeleteConfirmed(1);

            Assert.AreEqual("Index", actual.ViewName);
        }
    }
}
