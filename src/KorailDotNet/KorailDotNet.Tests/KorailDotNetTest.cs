using KorailDotNet.Param;
using System;
using Xunit;

namespace KorailDotNet.Tests
{

    public class KorailDotNetTest
    {
        private KorailDotNet korailDotNet;

        public KorailDotNetTest() {
            this.korailDotNet = new KorailDotNet();
        }

        private LoginParam GetLoginParam() {
            return new LoginParam() {
                LoginType = LoginType.PhoneNumber,
                MemberId = "010-2966-5905",
                Password = "zhfpdlf123!" // ÄÚ·¹ÀÏ123!
            };
        }

        [Fact(DisplayName = nameof(LoginSuccessTest))]
        public void LoginSuccessTest() {
            // Arrange
            var param = GetLoginParam();

            // Act
            korailDotNet.CreateSession(param);

            // Assert
            Assert.Equal(true, korailDotNet.HasSession);
        }

        [Fact(DisplayName = nameof(LoginFailTest))]
        public void LoginFailTest() {
            // Arrange
            var param = GetLoginParam();
            param.Password = "asdasd";

            var isError = false;

            // Act
            try {
                korailDotNet.CreateSession(param);
            } catch (Exception) {
                isError = true;
            }

            // Assert
            Assert.Equal(false, korailDotNet.HasSession);
            Assert.Equal(true, isError);
        }

        [Fact(DisplayName = nameof(SearchTrainTest))]
        public void SearchTrainTest() {
            // Arrange
            var param = GetLoginParam();

            // Act
            korailDotNet.CreateSession(param);

            // Assert
            
        }

    }
}
