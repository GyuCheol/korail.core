﻿using KorailDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorailDotNet.Param {

    // 00 Formatting
    public enum TrainType {
        KTX = 100,
        Samaeul = 101,
        Mugunghwa = 102,
        Tonggun = 103,
        Nuriro = 102,
        Airport = 105,
        KTX_SanCheon = 100,
        ITX_Samaeul = 101,
        ITX_ChengChun = 104,
        All = 109,
    }

    public class SearchTrainParam: BaseParam {

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
        

        [FormData("txtGoStart")]
        public String StartStation { get; set; }

        [FormData("txtGoEnd")]
        public String EndStation { get; set; }

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
        public String SearAttCode2 => "000";

        [FormData("txtSeatAttCd_3")]
        public String SearAttCode3 => "000";

        [FormData("txtSeatAttCd_4")]
        public String SearAttCode4 => "015";

        public DateTime TrainStartDateTime;

        public TrainType TrainType { get; set; } = TrainType.All;

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

        [FormData("selGoTrain")]
        public TrainType SelTrainType {
            get {
                return TrainType;
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
