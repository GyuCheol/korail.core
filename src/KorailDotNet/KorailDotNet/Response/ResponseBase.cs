using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KorailDotNet.Response
{

    public abstract class ResponseBase
    {
        [JsonProperty("h_msg_txt")]
        public String Message { get; set; }

        [JsonProperty("h_msg_cd")]
        public String MessageCode { get; set; }

        [JsonProperty("strResult")]
        public String Result { get; set; }

    }
}
