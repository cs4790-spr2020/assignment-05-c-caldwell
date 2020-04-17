using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;
using System.Threading;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestSetGetEmail_Success()
        {
            // Arrange
            User harness = new User(); 
            string expected = "foobar@example.com";
            harness.ChangeEmail("foobar@example.com");
            // Act
            string actual = harness.Email; // Assert
            Assert.AreEqual(actual.ToString(), expected.ToString());
        }
        [TestMethod]
        public void TestId()
        {
            // Arrange
            User harness = new User();
            Guid expected = harness.Id;
            // Act
            Guid actual = harness.Id;
            // Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(true, harness.Id is Guid);
        }
        [TestMethod]
        public void TestIdFail()
        {
            // Arrange
            User harness = new User();
            User newUser = new User();
            Guid expected = harness.Id;
            // Act
            Guid actual = newUser.Id;
            // Assert
            Assert.AreNotEqual(actual, expected);
        }
        [TestMethod]
        public void TestRegisterDTTM()
        {
            User Expected = new User();
            // Act
            Expected.RegisterDTTM = System.DateTime.Now;
            User Actual = new User();
            Actual.RegisterDTTM = System.DateTime.Now;
            // Assert
            Assert.AreEqual(Expected.RegisterDTTM.ToString(), Actual.RegisterDTTM.ToString());
        }
        [TestMethod]
        public void TestRegisterDTTMFail()
        {
            User Expected = new User();
            Expected.RegisterDTTM = System.DateTime.Now;
            Thread.Sleep(1000);
            User Actual = new User();
            Actual.RegisterDTTM = System.DateTime.Now;
            // Assert
            Assert.AreNotEqual(Expected.RegisterDTTM.ToString(), Actual.RegisterDTTM.ToString());
        }
        [TestMethod]
        public void TestLastLoginDTTM()
        {
            User Expected = new User();
            // Act
            Expected.LastLoginDTTM = System.DateTime.Now;
            User Actual = new User();
            Actual.LastLoginDTTM = System.DateTime.Now;
            // Assert
            Assert.AreEqual(Expected.LastLoginDTTM.ToString(), Actual.LastLoginDTTM.ToString());
        }
        [TestMethod]
        public void TestLastLoginDTTMFail()
        {
            User Expected = new User();
            Expected.LastLoginDTTM = System.DateTime.Now;
            Thread.Sleep(1000);
            User Actual = new User();
            Actual.LastLoginDTTM = System.DateTime.Now;
            // Assert
            Assert.AreNotEqual(Expected.LastLoginDTTM.ToString(), Actual.LastLoginDTTM.ToString());
        }
        [TestMethod]
        public void ChangeEmailFunction()
        {
            User user = new User("ccaldwell@mytrexinc.com");
            String oldEmail = "ccaldwell@mytrexinc.com";
            user.ChangeEmail("wankta@gmail.com");
            Assert.AreNotEqual(oldEmail, user.Email);
        }
        [TestMethod]
        public void notValid()
        {
            User user = new User();
            bool valid = user.IsValid();
            Assert.AreEqual(false, valid);
        }
        [TestMethod]
        public void isValid()
        {
            User user = new User("ccaldwell@mytrexinc.com");
            user.LastLoginDTTM = System.DateTime.Now;
            user.RegisterDTTM = System.DateTime.Now;
            bool valid = user.IsValid();
            Assert.AreEqual(true, valid);
        }
    }
}
