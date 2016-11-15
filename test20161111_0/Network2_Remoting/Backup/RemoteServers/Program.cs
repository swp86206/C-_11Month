using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels.Tcp;

namespace RemoteServers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Remote Server.");

            //IpcServerChannel objChannel = new IpcServerChannel("LabChannel");
            //// TcpServerChannel objChannel = new TcpServerChannel(4000);

            //ChannelServices.RegisterChannel(objChannel, true);

            //RemotingConfiguration.RegisterActivatedServiceType(typeof(RemoteObjects.CRemote));
            // RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObjects.CRemote), "CRemote.rem", WellKnownObjectMode.SingleCall);
            // RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObjects.CRemote), "CRemote.rem", WellKnownObjectMode.Singleton);

            RemotingConfiguration.Configure("RemoteServers.exe.config", true);

            Console.WriteLine("Remote Server is ready. Waiting for requests");
            Console.ReadLine();

        }
    }
}
