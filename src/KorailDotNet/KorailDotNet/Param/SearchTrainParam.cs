using KorailDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorailDotNet.Param {

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

        public Station StartStation { get; set; }
        
        public Station EndStation { get; set; }

        public DateTime TrainStartDateTime;

        public TrainType TrainType { get; set; } = TrainType.All;

        [FormData("txtGoStart")]
        public String StartStationName {
            get {
                return GetStation(StartStation);
            }
        }

        [FormData("txtGoEnd")]
        public String EndStationName {
            get {
                return GetStation(EndStation);
            }
        }

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

        private static String GetStation(Station station) {
            switch(station) {
                case Station.Seoul:
                    return "서울";
                case Station.Busan:
                    return "부산";
                default:
                    return null;
            }
        }

    }
}
