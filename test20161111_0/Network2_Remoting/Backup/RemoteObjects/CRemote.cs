using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteObjects
{
    public class CRemote : System.MarshalByRefObject
    {
        public CRemote()
        {
            Console.WriteLine("Trace: create a CRemote object instance. xxxxxxx");
        }

        public string SayHello(string yourName)
        {
            Console.WriteLine("Trace: SayHello called. yyyyyyy");
            return "Hello! " + yourName;
        }
    }
}
