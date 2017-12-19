using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorailDotNet.Response {

    [JsonObject(MemberSerialization.OptIn)]
    public class SessionResponse {

        [JsonProperty("strAthnFlg")]
        public String Flag { get; set; }

        [JsonProperty("strDiscCouponFlg")]
        public String DiscCouponFlag { get; set; }

        [JsonProperty("h_msg_txt")]
        public String Message { get; set; }

        [JsonProperty("h_msg_cd")]
        public String MessageCode { get; set; }

        [JsonProperty("strResult")]
        public String Result { get; set; }

        [JsonProperty("Key")]
        public String Key { get; set; }

        [JsonProperty("strMbCrdNo")]
        public String MemberNoId { get; set; }

        [JsonProperty("strDiscCrdReisuFlg")]
        public String DiscReisuFlag { get; set; }

        [JsonProperty("strCustMgSrtCd")]
        public String CustMgSrtCd { get; set; }

        [JsonProperty("strCustNo")]
        public String CustNo { get; set; }

        [JsonProperty("strCpNo")]
        public String PhoneNo { get; set; }

        [JsonProperty("strEmailAdr")]
        public String Email { get; set; }

        [JsonProperty("strAbrdStnCd")]
        public String StartStationCode { get; set; }

        [JsonProperty("strAbrdStnNm")]
        public String StartStationName { get; set; }
        
        [JsonProperty("strGoffStnNm")]
        public String EndStationName { get; set; }

        [JsonProperty("strGoffStnCd")]
        public String EndStationCode { get; set; }


    }
}
