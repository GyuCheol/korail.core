using System;
using System.Collections.Generic;
using System.Text;

namespace KorailDotNet.Exception
{
    public class NeedLoginException : KorailDotnetException {
        public NeedLoginException(): base("There is no session. First, execute 'Login'"){
        }
        
    }
}
