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
                MemberId = "id",
                Password = "pw"
            };
            // id, pw 정보 config 파일로 주입하게 해야함.
        }

        [Fact(DisplayName = nameof(LoginSuccessTest))]
        public void LoginSuccessTest() {
            // Arrange
            var param = GetLoginParam();

            // Act
            korail.Login(param);

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
                korail.Login(param);
            } catch (System.Exception) {
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
            korail.Login(loginParam);
            korail.SearchTrain(searchParam);

            // Assert

        }

        [Fact(DisplayName = nameof(LogoutTest))]
        public void LogoutTest() {
            // Arrange
            var loginParam = GetLoginParam();

            // Act
            korail.Login(loginParam);
            korail.Logout();

            // Assert
            Assert.Equal(false, korail.HasSession);
        }

    }
}
