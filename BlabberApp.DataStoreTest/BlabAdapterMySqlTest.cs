using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class BlabAdapter_MySql_UnitTests
    {
        private BlabAdapter _harness = new BlabAdapter(new MySqlBlab());
        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }
        
        [TestMethod]
        public void TestAddAndGetBlab()
        {
            //Arrange
            string email = "this@test.com";
            User mockUser = new User(email);
            Blab blab = new Blab("Now is the time for, blabs...", mockUser);
            _harness.Add(blab);
            ArrayList actual = (ArrayList)_harness.GetByUserId(email);
            _harness.Remove(blab);
            Assert.AreEqual(1, actual.Count);
        }
        [TestMethod]
        public void TestReadByID()
        {
            User mockUser = new User("ccaldwell@mytrexinc.com");
            Blab blab = new Blab("Now is the time for, blabs...", mockUser);
            _harness.Add(blab);
            Blab dbBlab = _harness.GetById(blab.Id);
            Assert.AreEqual(blab.Id, dbBlab.Id);
        }
        [TestMethod]
        public void TestReadByEmail()
        {
            User mockUser = new User("ccaldwell@mytrexinc.com");
            Blab blab = new Blab("Now is the time for, blabs...", mockUser);
            Blab blab1 = new Blab("Now is the time for, blabs...", mockUser);
            Blab blab2 = new Blab("Now is the time for, blabs...", mockUser);
            _harness.Add(blab);
            _harness.Add(blab1);
            _harness.Add(blab2);
            ArrayList actual = (ArrayList)_harness.GetByUserId(mockUser.Email);
            bool passed = false;
            if(actual.Count > 0){
                passed = true;
            }
            _harness.DeleteAll("ccaldwell@mytrexinc.com");
            Assert.AreEqual(passed, true);
        }
        [TestMethod]
        public void TestAddAndDeleteBlab()
        {
            User mockUser = new User("ccaldwell@mytrexinc.com");
            Blab blab = new Blab("Now is the time for, blabs...", mockUser);
            _harness.Add(blab);
            Blab dbBlab = _harness.GetById(blab.Id);
            _harness.Remove(blab);
            Blab newDBBlab = _harness.GetById(blab.Id);
            Assert.AreEqual(null, newDBBlab);
        }
         [TestMethod]
        public void TestUpdateBlab()
        {
            User mockUser = new User("ccaldwell@mytrexinc.com");
            Blab blab = new Blab("Now is the time for, blabs...", mockUser);
            _harness.Add(blab);
            blab.Message = "I Blabbed the wrong thing";
            _harness.Update(blab);
            Blab updatedBlab = _harness.GetById(blab.Id);
            Assert.AreEqual(updatedBlab.Id, blab.Id);
            Assert.AreEqual(updatedBlab.Message, blab.Message);
            _harness.DeleteAll("ccaldwell@mytrexinc.com");
        }

        [TestMethod]
        public void GetAll()
        {
            User mockUser = new User("ccaldwell@mytrexinc.com");
            Blab blab = new Blab("Now is the time for, blabs...", mockUser);
            _harness.Add(blab);
            ArrayList list = _harness.GetAll() as ArrayList;
            bool actual = false;
            if(list.Count > 0){
                actual = true;
            }
            Assert.AreEqual(actual, true);
        }
    }
}
