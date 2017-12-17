using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KorailDotNet.Tests {
    [TestClass]
    public class KorailDotNetTest {
        [TestMethod]
        public void LoginSuccessTest() {
            // Arrange
            // 코레일123!
            var korailDotNet = new KorailDotNet(LoginType.PhoneNumber, "010-2966-5905", "zhfpdlf123!");

            // Act
            korailDotNet.CreateSession();

            // Assert

        }

        [TestMethod]
        public void LoginFailTest() {
            // Arrange
            var korailDotNet = new KorailDotNet(LoginType.PhoneNumber, "010-2966-5905", "123111231211");

            // Act
            korailDotNet.CreateSession();

            // Assert

        }

    }
}
