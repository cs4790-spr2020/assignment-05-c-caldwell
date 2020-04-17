using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserAdapter_MySql_UnitTests
    {
        private User _user;
        private UserAdapter _harness = new UserAdapter(new MySqlUser());
        private readonly string _email = "foobar@example.com";

        [TestInitialize]
        public void Setup()
        {
            _user = new User(_email);
        }
        [TestCleanup]
        public void TearDown()
        {
            User user = new User(_email);
            _harness.DeleteAll(user.Email);
        }

        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void NullUsers()
        {
            User user = _harness.GetById(_user.Id);
            Assert.AreEqual(null, user);
        }

        [TestMethod]
        public void TestAddAndGetUser()
        {
            //Arrange
            _user.RegisterDTTM =DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            //Act
            _harness.Add(_user);
            User actual = _harness.GetById(_user.Id);
            //Assert
            Assert.AreEqual(_user.Id, actual.Id);
        }
        [TestMethod]
        public void TestAddAndGetAll()
        {
            bool count = false;
            _user.RegisterDTTM =DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            _harness.Add(_user);
            User secondUser = new User("wankta@gmail.com");
            secondUser.RegisterDTTM =DateTime.Now;
            secondUser.LastLoginDTTM = DateTime.Now;
            _harness.Add(secondUser);
            ArrayList users = (ArrayList)_harness.GetAll();
            if(users.Count > 1){
                count = true;
            }
            _harness.Remove(secondUser);
            Assert.AreEqual(count , true);
        }
        [TestMethod]
        public void TestRemoveUser()
        {
            _user.RegisterDTTM =DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            _harness.Add(_user);
            User dbRetrievedUser = _harness.GetByEmail(_user.Email);
            _harness.Remove(dbRetrievedUser);
            User newUser =  _harness.GetByEmail(dbRetrievedUser.Email);
            Assert.AreEqual(null, newUser);
            
        }
        [TestMethod]
        public void ReadByEmail()
        {
            _user.RegisterDTTM =DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            _harness.Add(_user);
            User dbRetrievedUser = _harness.GetByEmail(_user.Email);
            Assert.AreEqual(_user.Email, dbRetrievedUser.Email);
        }
        [TestMethod]
        public void ReadByID()
        {
            _user.RegisterDTTM =DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            _harness.Add(_user);
            User dbRetrievedUser = _harness.GetById(_user.Id);
            Assert.AreEqual(_user.Email, dbRetrievedUser.Email);
        }
        [TestMethod]
        public void UpdateUser()
        {
            User newUser = new User("wankta@gmail.com");
            newUser.RegisterDTTM =DateTime.Now;
            newUser.LastLoginDTTM = DateTime.Now;
            _harness.Add(newUser);
            newUser.ChangeEmail("ccaldwell@mytrexinc.com");
            _harness.Update(newUser);
            User dbRetrievedUser = _harness.GetById(newUser.Id);
            //To clean up after
            _harness.Remove(newUser);

            Assert.AreEqual(newUser.Email, dbRetrievedUser.Email);
        }
    }
}
