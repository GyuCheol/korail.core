using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KorailDotNet.Param;
using KorailDotNet.Attributes;

namespace KorailDotNet.Tests {
    [TestClass]
    public class KorailDotNetTest {
        [TestMethod]
        public void LoginSuccessTest() {
            // Arrange
            // 코레일123!
            var korailDotNet = new KorailDotNet(new LoginParam() {
                LoginType = LoginType.PhoneNumber,
                MemberId = "010-2966-5905",
                Password = "zhfpdlf123!"
            });

            // Act
            // Assert
            korailDotNet.CreateSession();

        }

        [TestMethod]
        public void LoginFailTest() {
            // Arrange
            var korailDotNet = new KorailDotNet(new LoginParam() {
                LoginType = LoginType.PhoneNumber,
                MemberId = "010-2966-5905",
                Password = "12312312!"
            });

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
            var korailDotNet = new KorailDotNet(new LoginParam() {
                LoginType = LoginType.PhoneNumber,
                MemberId = "010-2966-5905",
                Password = "zhfpdlf123!"
            });

            // Act
            korailDotNet.CreateSession();

            //korailDotNet.SearchTrain(TrainType.KTX, "수원", "동대구", DateTime.Now);
            //korailDotNet.SearchTrain(TrainType.Samaeul, "수원", "천안", DateTime.Now);

            // Assert
        }

        [TestMethod]
        public void AnnotationTest() {
            var param = new LoginParam() {
                LoginType = 0,
                MemberId = "asdasd",
                Password = "asdasda"
            };
            var type = param.GetType();
            var fields = type.GetFields();

            foreach (var field in fields) {
                Console.WriteLine(field.Name);

                var attributes = field.GetCustomAttributes(typeof(FormDataAttribute), false);

                foreach (var attr in attributes) {

                    Console.WriteLine(attr);
                }

            }
            
        }

    }
}
