using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace SelfHost
{

    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        string SayHello(string name);
    }
    public class HelloWorldService : IHelloWorldService
    {
        public string SayHello(string name)
        {
            return string.Format("Hello, {0}", name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/hello");
            ServiceHost host = new ServiceHost(typeof(HelloWorldService), baseAddress);
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);
            host.Open();
            Console.WriteLine("Service is running, press <Enter> to end");
            Console.ReadLine();
        }
    }
}
