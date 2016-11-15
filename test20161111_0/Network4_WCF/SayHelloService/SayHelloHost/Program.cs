using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace SayHelloHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(SayHelloService.CSayHello));
            host.Open();
            Console.WriteLine("Service is running, press <Enter> to exit");
            Console.ReadLine();
            host.Close();
        }
    }
}
