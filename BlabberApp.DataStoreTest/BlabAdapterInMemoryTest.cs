using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class BlabAdapter_InMemory_UnitTests 
    {
        private BlabAdapter _harness = new BlabAdapter(new InMemory());

        [TestMethod]
        public void ReadByUserID()
        {
            Blab blab = new Blab("I am blabbing");
            blab.DTTM = System.DateTime.Now;
            System.DateTime time = blab.DTTM;
            bool isValid = blab.IsValid();
            _harness.Add(blab);
            Blab expected = _harness.GetByUserId("wankta@gmail.com") as Blab;
            Assert.AreEqual(expected, null);
            Assert.AreEqual(true, isValid);
        }
        
    }
}
