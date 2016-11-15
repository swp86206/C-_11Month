using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelfHost_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.HelloWorldServiceClient ws = new ServiceReference1.HelloWorldServiceClient();
            Console.WriteLine(ws.SayHello("Tester"));
            Console.ReadLine();
        }
    }
}
