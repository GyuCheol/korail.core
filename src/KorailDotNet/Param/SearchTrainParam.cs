using KorailDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorailDotNet.Param {
    public class SearchTrainParam {

        [FormDataName("Device")]
        public readonly String Device = "AD";

        [FormDataName("radJobId")]
        public readonly String RadJobId = "1";

        [FormDataName("txtCardPsgCnt")]
        public readonly String CardPsgCount = "0";

        [FormDataName("txtGdNo")]
        public readonly String GdNo = "";

        [FormDataName("txtJobDv")]
        public readonly String JobDv = "";

        [FormDataName("txtMenuId")]
        public readonly String MenuId = "11";

        [FormDataName("Version")]
        public readonly String Version = "150718001";

        [FormDataName("selGoTrain")]
        public TrainType TrainType;

        [FormDataName("txtTrnGpCd")]
        public TrainType TrainGroupCode;

        [FormDataName("txtGoStart")]
        public String AbroadStationName;

        [FormDataName("txtGoEnd")]
        public String GoffStationName;

        [FormDataName("txtPsgFlg_1")]
        public int AdultCount;

        [FormDataName("txtPsgFlg_2")]
        public int ChildCount;

        [FormDataName("txtPsgFlg_3")]
        public int SeniorCount;

        [FormDataName("txtPsgFlg_4")]
        public int Disabled1Count;

        [FormDataName("txtPsgFlg_5")]
        public int Disabled2Count;

        [FormDataName("txtSeatAttCd_2")]
        public readonly int SearAttCode2 = 0;

        [FormDataName("txtSeatAttCd_3")]
        public readonly int SearAttCode3 = 0;

        [FormDataName("txtSeatAttCd_4")]
        public readonly int SearAttCode4 = 0;

        public DateTime TrainStartDateTime;


        [FormDataName("txtGoAbrdDt")]
        public String Date {
            get {
                return $"{TrainStartDateTime:yyyyMMdd}";
            }
        }

        [FormDataName("txtGoHour")]
        public String Hour {
            get {
                return $"{TrainStartDateTime:HHmmss}";
            }
        }

    }
}
