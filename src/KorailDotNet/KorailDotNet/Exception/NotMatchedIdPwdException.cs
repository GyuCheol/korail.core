using System;
using System.Collections.Generic;
using System.Text;

namespace KorailDotNet.Exception
{
    public class NotMatchedIdPwdException : KorailDotnetException {
        public NotMatchedIdPwdException(): base("Not matched the id and password.") {
        }
        
    }
}
