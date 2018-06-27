using BarcoSRestApi.Exceptions;
using BarcoSRestApi.Models;
using BarcoSRestApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarcoSUnitTest
{
    [TestClass]
    public class UserServiceTester
    {
        private readonly IUserService userService = new UserService();

      

        [TestMethod]
        public void AddingUserWithoutAuthName()
        {

            Assert.ThrowsException<ValidationException>(() => userService.AddUser("a", 1234, "",
                "SohNoQHtcGZsTH1JY5zkKiU8Whvp8VV5xWyaThNmb6nhwRK4YdYYIgEtO6AKDengijhMXtwsDhMaDLsZSnl9L5y2RzJ62duyPmXL"));

        }
        [TestMethod]
        public void AddingUserNormally()
        {
            user testUser = userService.AddUser("aasffasfsadsadasd", 1234, "asdd",
                "SohNoQHtcGZsTH1JY5zkKiU8Whvp8VV5xWyaThNmb6nhwRK4YdYYIgEtO6AKDengijhMXtwsDhMaDLsZSnl9L5y2RzJ62duyPmXL");
            Assert.AreNotEqual(null, testUser);
               
        }




        [TestMethod]
        public void AddingUserWithOutMail()
        {

            Assert.ThrowsException<ValidationException>(() => userService.AddUser("", 1234, "asdd",
                "SohNoQHtcGZsTH1JY5zkKiU8Whvp8VV5xWyaThNmb6nhwRK4YdYYIgEtO6AKDengijhMXtwsDhMaDLsZSnl9L5y2RzJ62duyPmXL"));

        }

        [TestMethod]
        public void GettingAllUsersWithoutToken()
        {

            Assert.AreEqual(null,
                userService.GetUsers(""));
        }


        




    }
}