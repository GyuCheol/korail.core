using KorailDotNet.Param;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace KorailDotNet.Classess {
    public class CookieWebRequest {
        private const int BUFFER_CAPACITY = 1 * 1024 * 100; // 100 kilo bytes

        private CookieContainer cookieContainer;

        public CookieWebRequest() {
            this.cookieContainer = new CookieContainer();
        }

        public String SendGet(String uri, BaseParam param) {
            String data = ParamToFormData.TransferFormData(param);

            if (String.IsNullOrWhiteSpace(data)) {
                uri += $"?{data}";
            }

            var response = GetHttpRequest(uri, HttpMethod.GET).GetResponse();

            return GetResponseString(0, response.GetResponseStream());

        }

        public String SendPost(String uri, BaseParam param) {
            String data = ParamToFormData.TransferFormData(param);

            var request = GetHttpRequest(uri, HttpMethod.POST);

            if (!String.IsNullOrWhiteSpace(data)) {
                var bytes_utf8 = Encoding.UTF8.GetBytes(data);

                request.GetRequestStream().Write(bytes_utf8, 0, bytes_utf8.Length);
            }

            var response = request.GetResponse();

            return GetResponseString(0, response.GetResponseStream());
        }

        private HttpWebRequest GetHttpRequest(String uri, HttpMethod method) {
            var httpReq = HttpWebRequest.Create(uri) as HttpWebRequest;

            httpReq.CookieContainer = this.cookieContainer;
            httpReq.Method = method.ToString();
            httpReq.UserAgent = "Dalvik/2.1.0 (Linux; U; Android 5.1.1; Nexus 4 Build/LMY48T)";
            httpReq.ContentType = "application/x-www-form-urlencoded";

            return httpReq;
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

    }
}
