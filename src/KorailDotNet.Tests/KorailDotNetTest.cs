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
            // Assert
            korailDotNet.CreateSession();

        }

        [TestMethod]
        public void LoginFailTest() {
            // Arrange
            var korailDotNet = new KorailDotNet(LoginType.PhoneNumber, "010-2966-5905", "123111231211");

            // Act
            // Assert
            Assert.ThrowsException<Exception>(() => {
                korailDotNet.CreateSession();
            });
        }

        [TestMethod]
        public void SearchTrainTest() {
            // Arrange
            // 코레일123!
            var korailDotNet = new KorailDotNet(LoginType.PhoneNumber, "010-2966-5905", "zhfpdlf123!");

            // Act
            korailDotNet.CreateSession();

            korailDotNet.SearchTrain(TrainType.KTX, "수원", "동대구", DateTime.Now);
            korailDotNet.SearchTrain(TrainType.Samaeul, "수원", "천안", DateTime.Now);

            // Assert
        }

    }
}
