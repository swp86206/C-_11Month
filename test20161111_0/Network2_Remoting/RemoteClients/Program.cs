using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels.Tcp;


namespace RemoteClients
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Remote Client.");

            //IpcClientChannel objChannel = new IpcClientChannel();
            //ChannelServices.RegisterChannel(objChannel, true);
            //RemotingConfiguration.RegisterActivatedClientType(typeof(RemoteObjects.CRemote), "ipc://LabChannel");

            //TcpClientChannel objChannel = new TcpClientChannel();
            //ChannelServices.RegisterChannel(objChannel, true);
            ////// RemotingConfiguration.RegisterActivatedClientType(typeof(RemoteObjects.CRemote), "tcp://YUKON:4000");
            //RemotingConfiguration.RegisterWellKnownClientType(typeof(RemoteObjects.CRemote), "tcp://YUKON:4000/CRemote.rem");

            RemotingConfiguration.Configure("RemoteClients.exe.config", true);
            
            Console.WriteLine("Client is ready to go. Press Enter to continue.");
            Console.ReadLine();

            RemoteObjects.CRemote obj = new RemoteObjects.CRemote();

            Console.WriteLine("Client Pause. Press Enter to continue.");
            Console.ReadLine();

            Console.WriteLine(obj.SayHello("Jeter"));
            Console.WriteLine(obj.SayHello("Jeter"));

            Console.WriteLine("Press Enter to end Client.");
            Console.ReadLine();
        }
    }
}
