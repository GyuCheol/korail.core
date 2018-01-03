using KorailDotNet.Classess;
using KorailDotNet.Exception;
using KorailDotNet.Param;
using KorailDotNet.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace KorailDotNet {

    internal enum UriType {
        Login,
        SearchTrain,
        Logout
    }

    public enum HttpMethod {
        POST,
        GET
    }

    public class KorailDotNet {
        private const String KORAIL_URL = "https://smart.letskorail.com:443/";
        private const String MOBILE_PATH = "classes/com.korail.mobile";
        private const String LOGIN_URI = ".login.Login";
        private const String SEARCH_TRAIN_URI = ".seatMovie.ScheduleView";
        private const String LOGOUT_URI = ".common.logout";

        public bool HasSession { get; private set; }
        
        private CookieWebRequest request;

        public KorailDotNet() {
            this.request = new CookieWebRequest();
        }

        public void Login(LoginParam loginParam) {
            var uri = GetURI(UriType.Login);
            var response = request.SendPost(uri, loginParam);
            var responseModel = JsonConvert.DeserializeObject<SessionResponse>(response);

            // 정상인 경우
            if (responseModel.MessageCode == "IRZ000001") {
                HasSession = true;
            } else {
                HasSession = false;
                // 로그인 에러
                throw new NotMatchedIdPwdException();
            }
        }

        public void Logout() {
            if(HasSession) {
                var uri = GetURI(UriType.Logout);
                var response = request.SendGet(uri, null);

                HasSession = false;
            } else {
                throw new NeedLoginException();
            }
        }

        public void SearchTrain(SearchTrainParam searchParam) {
            SessionChecker();

            var uri = GetURI(UriType.SearchTrain);
            var str = request.SendGet(uri, searchParam);

            Console.WriteLine(str);

            throw new NotImplementedException();
        }

        private void SessionChecker() {
            if (HasSession == false) {
                throw new NeedLoginException();
            }
        }
        
        private String GetURI(UriType type) {
            var sb = new StringBuilder(KORAIL_URL + MOBILE_PATH);

            switch(type) {
                case UriType.Login:
                    sb.Append(LOGIN_URI);
                    break;
                case UriType.SearchTrain:
                    sb.Append(SEARCH_TRAIN_URI);
                    break;
                case UriType.Logout:
                    sb.Append(LOGOUT_URI);
                    break;
            }
            
            return sb.ToString();
        }

    }
}
