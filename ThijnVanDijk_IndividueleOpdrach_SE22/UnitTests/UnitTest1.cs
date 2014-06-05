using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThijnVanDijk_IndividueleOpdrach_SE22;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LogInWithoutChannel()
        {
            // unit test code
            // arrange
            string userName = "Thijn";
            string password = "test123";
            string expected = "1";
            Controller Control = Controller.Instance;

            // act
            string reply = Control.LogIn(userName,password);

            // assert
            Assert.AreEqual(expected, reply, "Test LogInWithoutChannel Failed");
        }

        [TestMethod]
        public void LogInWithChannel()
        {
            // unit test code
            // arrange
            string userName = "Admin";
            string password = "test123";
            string expected = "WhaleTV";
            Controller Control = Controller.Instance;

            // act
            string reply = Control.LogIn(userName, password);

            // assert
            Assert.AreEqual(expected, reply, "Test LogInWithChannel Failed");
        }


    }
}
