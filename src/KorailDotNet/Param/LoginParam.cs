using KorailDotNet.Attributes;
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

    public class LoginParam: BaseParam {

        [FormData("txtPwd")]
        public String Password { get; set; }

        [FormData("txtMemberNo")]
        public String MemberId { get; set; }

        [FormData("txtInputFlg")]
        public LoginType LoginType { get; set; }
    }
}
