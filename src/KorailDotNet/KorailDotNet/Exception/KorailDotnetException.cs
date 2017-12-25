using System;
using System.Collections.Generic;
using System.Text;

namespace KorailDotNet.Exception
{
    public class KorailDotnetException : System.Exception {

        public KorailDotnetException(String errMsg):base(errMsg) {
            
        }

    }
}
