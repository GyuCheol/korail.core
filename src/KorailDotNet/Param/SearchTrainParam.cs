using KorailDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorailDotNet.Param {

    // 00 Formatting
    public enum TrainType {
        KTX = 0,
        Samaeul = 1,
        Mugunghwa = 2,
        Tonggun = 3,
        Nuriro = 4,
        All = 5,
        Airport = 6,
        KTX_SanCheon = 7,
        ITX_Samaeul = 8,
        ITX_ChengChun = 9
    }

    public class SearchTrainParam: BaseParam {

        [FormData("Device")]
        public String Device => "AD";

        [FormData("Version")]
        public String Version => "150718001ske";

        [FormData("radJobId")]
        public String RadJobId => "1";

        [FormData("txtCardPsgCnt")]
        public String CardPsgCount => "0";

        [FormData("txtGdNo")]
        public String GdNo => "";

        [FormData("txtJobDv")]
        public String JobDv => "";

        [FormData("txtMenuId")]
        public String MenuId => "11";

        [FormData("selGoTrain")]
        public TrainType TrainType { get; set; }

        [FormData("txtGoStart")]
        public String AbroadStationName { get; set; }

        [FormData("txtGoEnd")]
        public String GoffStationName { get; set; }

        [FormData("txtPsgFlg_1")]
        public int AdultCount { get; set; }

        [FormData("txtPsgFlg_2")]
        public int ChildCount { get; set; }

        [FormData("txtPsgFlg_3")]
        public int SeniorCount { get; set; }

        [FormData("txtPsgFlg_4")]
        public int Disabled1Count { get; set; }

        [FormData("txtPsgFlg_5")]
        public int Disabled2Count { get; set; }

        [FormData("txtSeatAttCd_2")]
        public int SearAttCode2 => 0;

        [FormData("txtSeatAttCd_3")]
        public int SearAttCode3 => 0;

        [FormData("txtSeatAttCd_4")]
        public int SearAttCode4 => 0;

        public DateTime TrainStartDateTime;

        [FormData("txtGoAbrdDt")]
        public String Date {
            get {
                return $"{TrainStartDateTime:yyyyMMdd}";
            }
        }

        [FormData("txtGoHour")]
        public String Hour {
            get {
                return $"{TrainStartDateTime:HHmmss}";
            }
        }

        [FormData("txtTrnGpCd")]
        public TrainType TrainGroupCode {
            get {
                return TrainType;
            }
        }

    }
}
