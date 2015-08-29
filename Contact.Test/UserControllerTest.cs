using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contact.Web.Controllers;
using System.Web.Mvc;
using Contact.Web.Models;
using Moq;
using Contact.Core.Interfaces.IManagers;
using Contact.Core.Models;

namespace Contact.Test
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mockManagers = new Mock<IManager>();
            var mockUserManager = new Mock<IUserManager>();

            var userId = 1;
            var email = "victor@gmail.com";
            var username = "vokosodo";

            mockUserManager.Setup(m => m.GetUserByID(It.IsAny<int>())).Returns(new UserModel
            {
                Email = email,
                UserID = userId,
                UserName = username
            });

            mockManagers.Setup(m => m.User).Returns(mockUserManager.Object);

            // Arrange: Create an instance to test:
            UserController controller = new UserController();
            // Act: Run the method under test:
            ViewResult result = controller.Delete(1) as ViewResult;
            // Assert: Verify the result:
            var user = (UserModel) result.Model;

            Assert.AreEqual(username, user.UserName);
            Assert.AreEqual(userId, user.UserID);
        }
    }
}
