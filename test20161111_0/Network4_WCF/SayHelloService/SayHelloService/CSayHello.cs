using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SayHelloInterface;

namespace SayHelloService
{
    public class CSayHello: ISayHello
    {
        public string SayHello(string sUserName)
        {
            return "Hello! " + sUserName;
        }
    }
}
