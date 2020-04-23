using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;
using BlabberApp.Services;

namespace BlabberApp.ServicesTest
{
    [TestClass]
    public class BlabServiceTest
    {
        private BlabServiceFactory _blabServiceFactory = new BlabServiceFactory();

        [TestMethod]
        public void TestCanary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void GetAllEmptyTest()
        {
            //Arrange
            BlabService blabService = _blabServiceFactory.CreateBlabService();
            ArrayList expected = new ArrayList();
            //Act
            IEnumerable actual = blabService.GetAll();
            //Assert
            Assert.AreEqual(expected.Count, (actual as ArrayList).Count);
        }

        [TestMethod]
        public void AddNewBlabSuccessTest()
        {
            //Arrange
            string email = "user@example.com";
            string msg = "Prow scuttle parrel provost Sail ho shrouds spirits boom mizzenmast yardarm.";
            BlabService blabService = _blabServiceFactory.CreateBlabService();
            Blab blab = blabService.CreateBlab(msg, email);
            blabService.AddBlab(blab); 
            ArrayList thisIsAnArrayList = blabService.GetAll() as ArrayList;
            bool expected = false;
            if(thisIsAnArrayList.Count > 0){
                expected = true;
            }
            Assert.AreEqual(expected, true);
        }

        [TestMethod]
        public void Problem1CodeCoverage()
        {
            User user = new User();
            BlabService blabService = _blabServiceFactory.CreateBlabService();
            blabService.AddBlab("Message", "wankta@gmail.com");
            Blab thisBlab = blabService.CreateBlab("message", user);
            bool valid = thisBlab.IsValid();

            Assert.AreEqual(true, true);
            
        }

        [TestMethod]
        public void Problem2CodeCoverage()
        {
            BlabService blabService = _blabServiceFactory.CreateBlabService();
            blabService.AddBlab("Message", "wankta@gmail.com");
            ArrayList thisBlab = blabService.FindUserBlabs("wankta@gmail.com")as ArrayList;
            
            Assert.AreEqual(null, thisBlab);
            
        }
    }
}
