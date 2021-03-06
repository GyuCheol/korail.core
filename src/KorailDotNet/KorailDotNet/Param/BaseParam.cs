﻿using KorailDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorailDotNet.Param {

    public enum LoginType {
        Email = 2,
        PhoneNumber = 4,
        MemberNumber = 5
    }

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

    public enum Station {
        Seoul,
        YongSan,
        GwangMyeong,
        YeongDeungPo,
        Suwon,
        PyeongTak,
        CheonAnAsan,
        CheonAn,
        Osong,
        JoChiWon,
        DaeJeon,
        SeoDaeJeon,
        KimCheonKumi,
        Kumi,
        DongDaegu,
        Daegu,
        UlSan,
        PoHang,
        GyeongSan,
        MillYang,
        Busan,
        ShinGyeongJu,
        KooPo,
        JinBoo,
        KangNeung,
        IkSan,
        JeonJu,
        ChangWonJongAng,
        PeongChang,
        GwangJuSongJeong,
        MokPo,
        SunCheon,
        CheongNyangRi
    }
    
    public abstract class BaseParam {
        [FormData("Device")]
        public String Device => "AD";

        [FormData("Version")]
        public String Version => "150718001";
    }
}
