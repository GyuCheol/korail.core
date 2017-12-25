using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KorailDotNet.Response
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SearchResponse: ResponseBase {

        [JsonObject(MemberSerialization.OptIn)]
        public class TrainInfo {
            [JsonProperty("h_trn_seq")]
            public String Sequence { get; set; }

            [JsonProperty("h_chg_trn_dv_cd")]
            public String ChangeTrainCode { get; set; }

            [JsonProperty("h_chg_trn_dv_nm")]
            public String ChangeTrainName { get; set; }

            [JsonProperty("h_chg_trn_seq")]
            public String ChangeTrainSequence { get; set; }

            [JsonProperty("h_dpt_rs_stn_cd")]
            public String DepartStaionCode { get; set; }

            [JsonProperty("h_dpt_rs_stn_nm")]
            public String DepartStaionName { get; set; }

            [JsonProperty("h_arv_rs_stn_cd")]
            public String ArriveStaionCode { get; set; }

            [JsonProperty("h_arv_rs_stn_nm")]
            public String ArriveStaionName { get; set; }

            [JsonProperty("h_trn_no")]
            public String TrainNo { get; set; }

            [JsonProperty("h_trn_no_qb")]
            public String TrainNoQb { get; set; }

            [JsonProperty("h_run_dt")]
            public String RunDate { get; set; }

            [JsonProperty("h_dpt_dt")]
            public String DepartDate { get; set; }

            [JsonProperty("h_dpt_tm")]
            public String DepartTime { get; set; }

            [JsonProperty("h_arv_dt")]
            public String ArriveDate { get; set; }

            [JsonProperty("h_arv_tm")]
            public String ArriveTime { get; set; }

            [JsonProperty("h_expct_dlay_hr")]
            public String DelayHour { get; set; }

            [JsonProperty("h_rsv_wait_ps_cnt")]
            public String RsvWaitPsCount { get; set; }

            [JsonProperty("h_rcvd_amt")]
            public String Amount { get; set; }

        }

        [JsonObject(MemberSerialization.OptIn)]
        public class TrainInfoItem {
            [JsonProperty("trn_info")]
            public TrainInfo[] TrainInfo { get; set; }
        }

        [JsonProperty("strJobId")]
        public String JobId { get; set; }

        [JsonProperty("h_menu_id")]
        public String MenuId { get; set; }

        [JsonProperty("h_seat_cnt_first")]
        public String SeatCountFirst { get; set; }

        [JsonProperty("h_seat_cnt_second")]
        public String SeatCountSecound { get; set; }

        [JsonProperty("h_next_pg_flg")]
        public String NextPageFlag { get; set; }

        [JsonProperty("h_rslt_cnt")]
        public int ResultCount { get; set; }

        [JsonProperty("trn_infos")]
        public TrainInfoItem TrainInfos { get; set; }

    }
}
