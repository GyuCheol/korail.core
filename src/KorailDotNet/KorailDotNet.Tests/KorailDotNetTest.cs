using KorailDotNet.Param;
using System;
using Xunit;

namespace KorailDotNet.Tests
{

    public class KorailDotNetTest
    {
        private KorailDotNet korail;

        public KorailDotNetTest() {
            this.korail = new KorailDotNet();
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
            korail.CreateSession(param);

            // Assert
            Assert.Equal(true, korail.HasSession);
        }

        [Fact(DisplayName = nameof(LoginFailTest))]
        public void LoginFailTest() {
            // Arrange
            var param = GetLoginParam();
            param.Password = "asdasd";

            var isError = false;

            // Act
            try {
                korail.CreateSession(param);
            } catch (Exception) {
                isError = true;
            }

            // Assert
            Assert.Equal(false, korail.HasSession);
            Assert.Equal(true, isError);
        }

        [Fact(DisplayName = nameof(SearchTrainTest))]
        public void SearchTrainTest() {
            // Arrange
            var loginParam = GetLoginParam();
            var searchParam = new SearchTrainParam() {
                AdultCount = 1,
                StartStation = Station.Seoul,
                EndStation = Station.Busan,
                TrainType = TrainType.KTX,
                TrainStartDateTime = DateTime.Now
            };

            // Act
            korail.CreateSession(loginParam);
            korail.SearchTrain(searchParam);

            // Assert

        }

        [Fact(DisplayName = nameof(LogoutTest))]
        public void LogoutTest() {
            // Arrange
            var loginParam = GetLoginParam();

            // Act
            korail.CreateSession(loginParam);
            korail.CloseSession();

            // Assert
            Assert.Equal(false, korail.HasSession);
        }

    }
}
