using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;
using BlabberApp.Services;
using BlabberApp.DataStore;

namespace BlabberApp.ServicesTest
{
    [TestClass]
    public class BlabServiceFactoryTest
    {
        BlabServiceFactory harness = new BlabServiceFactory();

        [TestMethod]
        public void CanaryTest()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void BuildAdapterTest()
        {
            //Arrange and Act
            BlabAdapter blabAdapter = harness.CreateBlabAdapter();
            //Assert
            Assert.IsTrue(blabAdapter is BlabAdapter);
        }
        [TestMethod]
        public void BuildServiceAdapterPluginTest()
        {
            //Arrange and Act
            BlabService blabService = harness.CreateBlabService();
            //Assert
            Assert.IsTrue(blabService is BlabService);
        }
        [TestMethod]
        public void BuildMySqlPlugin()
        {
            BlabAdapter blabAdapter = harness.CreateBlabAdapter(harness.CreateBlabPlugin("MYSQL"));
            Assert.IsTrue(blabAdapter is BlabAdapter);
        }
        [TestMethod]
        public void BuildMySqlPluginLowerCase()
        {
            BlabAdapter blabAdapter = harness.CreateBlabAdapter(harness.CreateBlabPlugin("mysql"));
            Assert.IsTrue(blabAdapter is BlabAdapter);
        }

    }
}
