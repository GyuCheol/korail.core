using KorailDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorailDotNet.Param {
    public abstract class BaseParam {
        [FormData("Device")]
        public String Device => "AD";

        [FormData("Version")]
        public String Version => "150718001";
    }
}
