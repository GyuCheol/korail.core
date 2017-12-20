﻿using KorailDotNet.Param;
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
        public const String LOGOUT_URI = ".common.logout";

        private const int BUFFER_CAPACITY = 1 * 1024 * 100; // 100 kilo bytes

        public bool HasSession { get; private set; }
        
        private CookieContainer cookieContainer;

        public KorailDotNet() {
            cookieContainer = new CookieContainer();
        }

        public void CreateSession(LoginParam loginParam) {
            var uri = GetURI(UriType.Login);
            var response = SendMessage(uri, loginParam, HttpMethod.POST);
            var responseModel = JsonConvert.DeserializeObject<SessionResponse>(response);

            // 정상인 경우
            if (responseModel.MessageCode == "IRZ000001") {
                HasSession = true;
            } else {
                HasSession = false;
                // 로그인 에러
                throw new Exception("Not matched the id and password.");
            }
        }

        public void CloseSession() {
            if(HasSession) {
                var uri = GetURI(UriType.Logout);
                var response = SendMessage(uri, null, HttpMethod.GET);

                Console.WriteLine(response);

                HasSession = false;
            }
        }

        public void SearchTrain(SearchTrainParam searchParam) {
            SessionChecker();

            var uri = GetURI(UriType.SearchTrain);
            var str = SendMessage(uri, searchParam, HttpMethod.GET);

            Console.WriteLine(str);

            throw new NotImplementedException();
        }

        private void SessionChecker() {
            if (HasSession == false) {
                throw new Exception("There is no session. First, execute 'CreateSession'");
            }
        }
        
        private String SendMessage(String uri, BaseParam param, HttpMethod method) {
            String data = ParamToFormData.TransferFormData(param);

            // Method가 GET인 경우, uri에 data를 붙인다.
            if (method == HttpMethod.GET && !String.IsNullOrWhiteSpace(data)) {
                uri += $"?{data}";
            }
            
            var request = HttpWebRequest.Create(uri) as HttpWebRequest;

            request.CookieContainer = cookieContainer;
            request.Method = method.ToString();
            request.UserAgent = "Dalvik/2.1.0 (Linux; U; Android 5.1.1; Nexus 4 Build/LMY48T)";
            request.ContentType = "application/x-www-form-urlencoded";

            if (method == HttpMethod.POST && !String.IsNullOrWhiteSpace(data)) {
                var buffer = Encoding.UTF8.GetBytes(data);

                request.GetRequestStream().Write(buffer, 0, buffer.Length);
            }

            var response = request.GetResponse();

            return GetResponseString(0, response.GetResponseStream());
        }

        private String GetResponseString(int size, Stream stream) {
            var buffer = new byte[BUFFER_CAPACITY];
            int length = -1;

            using (var ms = new MemoryStream(size)) {
                while (length != 0) {
                    length = stream.Read(buffer, 0, BUFFER_CAPACITY);
                    ms.Write(buffer, 0, length);
                }
                return Encoding.UTF8.GetString(ms.ToArray());
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
