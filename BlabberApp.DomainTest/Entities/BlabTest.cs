using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;
using System.Threading;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class BlabTest
    {       
        private Blab harness;
        public BlabTest() 
        {
            harness = new Blab();
        }
        [TestMethod]
        public void TestSetGetMessage()
        {
            // Arrange
            string expected = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."; 
            harness.Message = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";
            // Act
            string actual = harness.Message;
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestSetGetMessageFail()
        {
            // Arrange
            string expected = "This is what I am expecting"; 
            harness.Message = "This is what it actually is";
            // Act
            string actual = harness.Message;
            // Assert
            Assert.AreNotEqual(actual, expected);
        }

        [TestMethod]
        public void TestId()
        {
            Assert.AreEqual(harness.Id, harness.Id);
            Assert.AreEqual(true, harness.Id is Guid);
        }
        
        [TestMethod]
        public void TestIdFail()
        {
            Blab newBlab = new Blab();
            Assert.AreNotEqual(newBlab.Id, harness.Id);
        }

        [TestMethod]
        public void TestDTTM()
        {
            // Arrange
            Blab Expected = new Blab();
            // Act
            Blab Actual = new Blab();
            // Assert
            Assert.AreEqual(Expected.DTTM.ToString(), Actual.DTTM.ToString());
        }

        [TestMethod]
        public void TestDTTMFail()
        {
            // Arrange
            Blab Expected = new Blab();
            Thread.Sleep(1000);
            Blab Actual = new Blab();
            // Assert
            Assert.AreNotEqual(Expected.DTTM.ToString(), Actual.DTTM.ToString());
        }

        [TestMethod]
        public void TestConstructorWithMessage()
        {
            Blab blab = new Blab("This is my message");
            Assert.AreEqual(blab.Message, "This is my message");
        }

        [TestMethod]
        public void TestConstructorWithUser()
        {
            User user = new User("ccaldwell@mytrexinc.com");
            Blab blab = new Blab(user);
            Assert.AreEqual(blab.User.Email, "ccaldwell@mytrexinc.com");
        }

        [TestMethod]
        public void TestConstructorWithUserAndBlab()
        {
            User user = new User("ccaldwell@mytrexinc.com");
            Blab blab = new Blab("I am blabbing", user);
            Assert.AreEqual(blab.User.Email, "ccaldwell@mytrexinc.com");
            Assert.AreEqual(blab.Message, "I am blabbing");
        }

        [TestMethod]
        public void TestConstructorWithString()
        {
            Blab blab = new Blab("This is a blab");
            Assert.AreEqual(blab.Message, "This is a blab");
        }

        [TestMethod]
        public void DTTMGetSet()
        {
            Blab blab = new Blab("This is a blab");
            blab.DTTM = System.DateTime.Now;
            DateTime expected = System.DateTime.Now;
            Assert.AreEqual(blab.DTTM.ToString(), expected.ToString());

        }

        [TestMethod]
        public void isValid()
        {
            Blab blab = new Blab("This is a blab");
            bool expected = blab.IsValid();
            Assert.AreEqual(true, expected);

        }
    }
}
