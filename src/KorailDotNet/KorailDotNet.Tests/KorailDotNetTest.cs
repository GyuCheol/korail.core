using KorailDotNet.Param;
using System;
using Xunit;

namespace KorailDotNet.Tests
{

    public class KorailDotNetTest
    {
        [Fact(DisplayName = nameof(LoginSuccessTest))]
        public void LoginSuccessTest() {
            // Arrange
            // 内饭老123!
            var korailDotNet = new KorailDotNet(new LoginParam() {
                LoginType = LoginType.PhoneNumber,
                MemberId = "010-2966-5905",
                Password = "zhfpdlf123!"
            });

            // Act
            korailDotNet.CreateSession();

            // Assert
            Assert.Equal(true, korailDotNet.HasSession);
        }

        [Fact(DisplayName = nameof(LoginFailTest))]
        public void LoginFailTest() {
            // Arrange
            // 内饭老123!
            var korailDotNet = new KorailDotNet(new LoginParam() {
                LoginType = LoginType.PhoneNumber,
                MemberId = "010-2966-5905",
                Password = "asda!"
            });
            var isError = false;

            // Act
            try {
                korailDotNet.CreateSession();
            } catch(Exception) {
                isError = true;
            }

            // Assert
            Assert.Equal(false, korailDotNet.HasSession);
            Assert.Equal(true, isError);
        }

    }
}
